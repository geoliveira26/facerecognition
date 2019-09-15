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
        private CascadeClassifier _cascadeClassifier;
        private Action<Image<Bgr, byte>, Image<Bgr, byte>, List<Image<Gray, byte>>> _onFaceDetected;

        public VideoFeed()
        {
            _cascadeClassifier = new CascadeClassifier($"{Application.StartupPath}/assets/haarcascade_frontalface_alt_tree.xml");
            _videoCapture = new VideoCapture();
            _videoCapture.ImageGrabbed += ProcessFrame;
            _videoCapture.Start();
        }

        public void ClearEvents() => _onFaceDetected = null;

        public void OnFaceDetected(Action<Image<Bgr, byte>, Image<Bgr, byte>, List<Image<Gray, byte>>> onFaceDetected)
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
            var faces = _cascadeClassifier.DetectMultiScale(image.Convert<Gray, byte>(), 1.5, 0, Size.Empty)
                .ToList()?
                .Select(face =>
                {
                    var rect = image.GetSubRect(face).Clone().Convert<Gray, byte>();
                    image.Draw(face, new Bgr(Color.BlueViolet), 2);
                    return rect;
                })?
                .ToList();

            if(_onFaceDetected != null)
                _onFaceDetected(image, originalImage, faces ?? new List<Image<Gray, byte>>());
        }
    }
}