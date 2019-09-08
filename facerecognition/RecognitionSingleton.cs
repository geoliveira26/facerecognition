using Emgu.CV.Face;
using facerecognition.Components;
using facerecognition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facerecognition
{
    public static class RecognitionSingleton
    {
        public static List<User> Users = new List<User>();

        public static FaceRecognizer FaceRecognizer;

        public static VideoFeed VideoFeed = new VideoFeed();
    }
}