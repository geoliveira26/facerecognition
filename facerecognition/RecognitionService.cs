using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using facerecognition.Models;
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
            _faceRecognizer = new EigenFaceRecognizer(RecognitionSingleton.Users.Count(), double.PositiveInfinity);
            TrainRecognizer();
        }

        private void TrainRecognizer()
        {
            if (!RecognitionSingleton.Users.Any())
                return;

            var users = RecognitionSingleton.Users;
            var faceImages = new Mat[users.Count];
            var faceLabels = new int[users.Count];

            RecognitionSingleton
                .Users
                .ForEach(u => u.Photos.ForEach(p =>
                {
                    var index = users.IndexOf(u);
                    faceImages[index] = p.Mat;
                    faceLabels[index] = u.Id;
                }));

            _faceRecognizer.Train(faceImages, faceLabels);

            _engineTrained = true;
        }

        public Recognition RecognizeUser(Image<Gray, byte> userImage)
        {
            if (!_engineTrained || userImage == null)
                return null;

            var result = _faceRecognizer.Predict(userImage);
            if (result.Label == 0)
                return null;

            return new Recognition { Prediction = result, User = RecognitionSingleton.Users.SingleOrDefault(_ => _.Id == result.Label) };
        }
    }
}
