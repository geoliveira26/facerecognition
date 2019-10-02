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

        public static void ChooseFace(Action<Image<Bgr, byte>, Image<Gray, byte>> afterChoose)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var image = new Image<Bgr, byte>(dlg.FileName);
                    var face = RecognitionSingleton.VideoFeed.GetFaceOnImage(image);
                    if (face == null)
                    {
                        MessageBox.Show("Nenhuma face detectada");
                        return;
                    }

                    afterChoose(image, face);
                }
            }
        }
    }
}