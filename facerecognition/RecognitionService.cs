using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using facerecognition.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace facerecognition
{
    public class RecognitionService
    {
        private bool _engineTrained;
        private FaceRecognizer _faceRecognizer;
        private string _recognizerFilePath = $"{Application.StartupPath}/assets/trained_recognitions.yaml";

        public RecognitionService()
        {
            _faceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
            TrainRecognizer();
        }

        private void TrainRecognizer()
        {
            if (!RecognitionSingleton.Users.Any())
                return;

            var faceImages = new List<Mat>();
            var faceLabels = new List<int>();

            RecognitionSingleton
                .Users
                .ForEach(u => u.Photos.ForEach(p =>
                {
                    faceImages.Add(p.Resize(100, 100, Inter.Cubic).Mat);
                    faceLabels.Add(u.Id);
                }));

            _faceRecognizer.Train(faceImages.ToArray(), faceLabels.ToArray());
            _faceRecognizer.Write(_recognizerFilePath);

            _engineTrained = true;
        }

        public void AddUser(User user)
        {
            RecognitionSingleton.Users.Add(user);
            TrainRecognizer();
        }

        public int? RecognizeUser(Image<Gray, byte> userImage)
        {
            /*  Stream stream = new MemoryStream();
              stream.Write(userImage, 0, userImage.Length);
              var faceImage = new Image<Gray, byte>(new Bitmap(stream));*/
            //_faceRecognizer.Read(_recognizerFilePath);
            if (!_engineTrained || userImage == null)
                return null;

            var result = _faceRecognizer.Predict(userImage.Resize(100, 100, Inter.Cubic).Mat);
            return result.Label;
        }
    }
}
