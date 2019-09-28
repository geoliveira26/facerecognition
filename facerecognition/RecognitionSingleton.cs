using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using facerecognition.Components;
using facerecognition.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facerecognition
{
    public static class RecognitionSingleton
    {
        public static List<User> Users = new List<User>();

        public static FaceRecognizer FaceRecognizer;

        public static CascadeClassifier CascadeClassifier;

        public static VideoFeed VideoFeed = new VideoFeed();

        public static Image<Gray, byte> GetFace(Image<Bgr, byte> image)
        {
            return GetFace(image.Convert<Gray, byte>());
        }

        public static List<Rectangle> GetFaceRectangles(Image<Gray, byte> image)
        {
            return CascadeClassifier?
                .DetectMultiScale(image, 1.1, 10)
                .ToList();
        }

        public static List<Rectangle> GetFaceRectangles(Image<Bgr, byte> image)
        {
            return GetFaceRectangles(image.Convert<Gray, byte>());
        }

        public static Image<Gray, byte> GetFace(Image<Gray, byte> image)
        {
            return GetFaceRectangles(image)
                .Select(_ => image.GetSubRect(_))
                .FirstOrDefault()
                ?.Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic)
                ?.Clone();
        }
    }
}