using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using System;
using System.IO;
using System.Linq;

namespace facerecognition
{
    public class RecognitionService
    {
        private FaceRecognizer _faceRecognizer;
        private String _recognizerFilePath;

        public RecognitionService(String databasePath, String recognizerFilePath)
        {
            _recognizerFilePath = recognizerFilePath;
            _faceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
        }

        public void TrainRecognizer()
        {
            var allFaces = _dataStoreAccess.CallFaces("ALL_USERS");
            if (allFaces == null)
                return;

            var faceImages = new Image<Gray, byte>[allFaces.Count];
            var faceLabels = new int[allFaces.Count];
            for (int i = 0; i < allFaces.Count; i++)
            {
                var stream = new MemoryStream();
                stream.Write(allFaces[i].Image, 0, allFaces[i].Image.Length);
                var faceImage = new Image<Gray, byte>(new Bitmap(stream));
                faceImages[i] = faceImage.Resize(100, 100, Inter.Cubic);
                faceLabels[i] = allFaces[i].UserId;
            }

            _faceRecognizer.Train(faceImages, faceLabels);
            _faceRecognizer.Write(_recognizerFilePath);
        }

        public void LoadRecognizerData()
        {
            _faceRecognizer.Read(_recognizerFilePath);
        }

        public int RecognizeUser(Image<Gray, byte> userImage)
        {
            /*  Stream stream = new MemoryStream();
              stream.Write(userImage, 0, userImage.Length);
              var faceImage = new Image<Gray, byte>(new Bitmap(stream));*/
            _faceRecognizer.Read(_recognizerFilePath);

            var result = _faceRecognizer.Predict(userImage.Resize(100, 100, Inter.Cubic));
            return result.Label;
        }
    }
}
