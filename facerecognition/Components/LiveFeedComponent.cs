using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace facerecognition.Components
{
    public abstract class LiveFeedComponent : Form
    {
        public LiveFeedComponent()
        {
            RecognitionSingleton.VideoFeed.OnFaceDetected(OnFaceDetected);

            FormClosing += (s, a) => RecognitionSingleton.VideoFeed.ClearEvents();
        }

        public abstract void OnFaceDetected(Image<Bgr, byte> image, Image<Bgr, byte> originalImage, List<Image<Gray, byte>> faces);
    }
}