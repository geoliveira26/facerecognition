using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using facerecognition.Components;
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
    public partial class FormDetector : LiveFeedComponent
    {
        private RecognitionService _recognitionService;

        public FormDetector()
        {
            InitializeComponent();

            _recognitionService = new RecognitionService();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonNewRecognition_Click(object sender, EventArgs e)
        {
            Hide();
            var form = new FormTrainer();
            form.ShowDialog();
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public override void OnFaceDetected(Image<Bgr, byte> image, Image<Bgr, byte> originalImage, List<Image<Gray, byte>> faces)
        {
            imgCamUser.Invoke(new MethodInvoker(() => imgCamUser.Image = image));
            label1.Invoke(new MethodInvoker(() => label1.Text = _recognitionService.RecognizeUser(faces.FirstOrDefault())?.ToString()));
        }
    }
}
