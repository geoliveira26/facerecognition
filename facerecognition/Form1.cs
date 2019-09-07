using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace facerecognition
{
    public partial class Form1 : Form
    {
        private VideoCapture _videoCapture;
        private CascadeClassifier _cascadeClassifier;

        public Form1()
        {
            InitializeComponent();

            _cascadeClassifier = new CascadeClassifier($"{Application.StartupPath}/assets/haarcascade_frontalface_alt_tree.xml");

            _videoCapture = new VideoCapture();
            _videoCapture.ImageGrabbed += ProcessFrame;
            _videoCapture.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_videoCapture != null && _videoCapture.Ptr != IntPtr.Zero)
            {
                var mat = new Mat();
                _videoCapture.Retrieve(mat, 0);

                var image = mat.ToImage<Bgr, Byte>();
                var faces = _cascadeClassifier.DetectMultiScale(image.Convert<Gray, byte>(), 1.5, 0, Size.Empty);

                foreach (var face in faces)
                    image.Draw(face, new Bgr(Color.BlueViolet), 2);

                imgCamUser.Image = image;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            FaceRecognizer ok = new FaceRecognizer()



            //using (var imageFrame = _videoCapture.QueryFrame().ToImage<Bgr, Byte>())
            //{
            //    if (imageFrame != null)
            //    {

            //    }

            //    imgCamUser.Image = imageFrame;
            //}
        }
    }
}
