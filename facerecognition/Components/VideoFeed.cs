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
        //private List<Image<Bgr, byte>> _faces;
        private VideoCapture _videoCapture;
        private Action<Image<Bgr, byte>, Image<Bgr, byte>, Image<Gray, byte>> _onFaceDetected;

        public VideoFeed()
        {
            RecognitionSingleton.CascadeClassifier = new CascadeClassifier($"{Application.StartupPath}/assets/haarcascade_frontalface_alt2.xml");
            _videoCapture = new VideoCapture();
            _videoCapture.ImageGrabbed += ProcessFrame;
            _videoCapture.Start();
        }

        public void ClearEvents() => _onFaceDetected = null;

        public void OnFaceDetected(Action<Image<Bgr, byte>, Image<Bgr, byte>, Image<Gray, byte>> onFaceDetected)
        {
            _onFaceDetected = onFaceDetected;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_videoCapture == null || _videoCapture.Ptr == IntPtr.Zero || !_videoCapture.IsOpened)
                return;

            var mat = new Mat();
            _videoCapture.Retrieve(mat, 0);

            var image = mat.ToImage<Bgr, byte>();
            var originalImage = image.Clone();
            var faceDetected = RecognitionSingleton.GetFaceRectangles(image)
                .Select(face =>
                {
                    var rect = image.GetSubRect(face).Clone().Convert<Gray, byte>();
                    image.Draw(face, new Bgr(Color.BlueViolet), 2);
                    return rect;
                })?
                .FirstOrDefault();

            if(_onFaceDetected != null)
                _onFaceDetected(image, originalImage, faceDetected);
        }
    }
}