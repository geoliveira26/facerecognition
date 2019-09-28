using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Windows.Forms;

namespace facerecognition
{
    public partial class FormDetector : Form
    {
        private RecognitionService _recognitionService;

        public FormDetector()
        {
            InitializeComponent();
            Load += (s, a) => RecognitionSingleton.VideoFeed.OnFaceDetected(OnFaceDetected);
            FormClosing += (s, a) => RecognitionSingleton.VideoFeed.ClearEvents();

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

        public void OnFaceDetected(Image<Bgr, byte> image, Image<Bgr, byte> originalImage, Image<Gray, byte> face)
        {
            imgCamUser.Invoke(new MethodInvoker(() => imgCamUser.Image = image));
            //label1.Invoke(new MethodInvoker(() => label1.Text = _recognitionService.RecognizeUser(faces.FirstOrDefault())?.Name));
        }
    }
}
