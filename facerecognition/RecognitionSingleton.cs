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
using System.Windows.Forms;

namespace facerecognition
{
    public static class RecognitionSingleton
    {
        public static List<User> Users = new List<User>();

        public static FaceRecognizer FaceRecognizer;

        public static VideoFeed VideoFeed = new VideoFeed();
    }
}