using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace facerecognition.Components
{
    public class VideoFeed
    {
        public Image<Bgr, byte> CamImage { get; private set; }
        public Image<Bgr, byte> CamImageWithFace { get; private set; }
        public Image<Gray, byte> LastRecognizedFace { get; private set; }

        private CascadeClassifier _classifier = new CascadeClassifier($"{Application.StartupPath}/assets/haarcascade_frontalface_alt2.xml");
        private VideoCapture _videoCapture;
        private List<Action<VideoFeed>> _subscribes = new List<Action<VideoFeed>>();

        public VideoFeed()
        {
            _videoCapture = new VideoCapture();
            _videoCapture.ImageGrabbed += ProcessFrame;
            _videoCapture.Start();
        }

        public void Start() => _videoCapture.Start();

        public void Pause() => _videoCapture.Pause();

        public void ClearEvents()
        {

        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_videoCapture == null || _videoCapture.Ptr == IntPtr.Zero || !_videoCapture.IsOpened)
                return;

            var mat = new Mat();
            _videoCapture.Retrieve(mat, 0);
            CamImage = mat.ToImage<Bgr, byte>();

            var faceRectangle = GetFaceRectangle(CamImage);
            if (!faceRectangle.IsEmpty)
            {
                LastRecognizedFace = GetFaceOnImage(CamImage, faceRectangle);
                CamImageWithFace = CamImage.Clone();
                CamImageWithFace.Draw(faceRectangle, new Bgr(Color.BlueViolet), 2);
            }
            else
            {
                CamImageWithFace = null;
                LastRecognizedFace = null;
            }

            foreach (var subscribe in _subscribes)
                subscribe(this);
        }

        public Rectangle GetFaceRectangle(Image<Bgr, byte> image)
        {
            return _classifier.DetectMultiScale(image.Mat, 1.1, 10).FirstOrDefault();
        }

        public Image<Gray, byte> GetFaceOnImage(Image<Bgr, byte> image, Rectangle? rectangle = null)
        {
            rectangle = rectangle ?? GetFaceRectangle(image);
            if (rectangle.Value.IsEmpty)
                return null;

            return image?.GetSubRect(rectangle.Value).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
        }

        public void Subscribe(Action<VideoFeed> feed)
        {
            _subscribes.Add(feed);
            Start();
        }

        public void Unsubscribe(Action<VideoFeed> feed) => _subscribes.Remove(feed);
    }
}