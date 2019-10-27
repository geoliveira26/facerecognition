using Emgu.CV;
using Emgu.CV.Structure;
using facerecognition.Components;
using facerecognition.Models;
using System;
using System.Windows.Forms;

namespace facerecognition
{
    public partial class FormDetector : Form
    {
        private RecognitionService _recognitionService;
        private Recognition _lastRecognition;
        private bool _lockCam;

        public FormDetector()
        {
            InitializeComponent();
            Load += (s, a) => RecognitionSingleton.VideoFeed.Subscribe(OnFaceDetected);
            FormClosing += (s, a) => RecognitionSingleton.VideoFeed.Unsubscribe(OnFaceDetected);

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

        public void OnFaceDetected(VideoFeed feed)
        {
            if (_lockCam)
                return;

            Recognize(feed.CamImageWithFace ?? feed.CamImage, feed.LastRecognizedFace);
        }

        private void Recognize(Image<Bgr, byte> image, Image<Gray, byte> face)
        {
            imgCamUser.Invoke(new MethodInvoker(() => imgCamUser.Image = image));
            label1.Invoke(new MethodInvoker(() =>
            {
                buttonEnter.Visible = false;
                var recognition = _recognitionService.RecognizeUser(face);
                if (recognition != null)
                {
                    _lastRecognition = recognition;
                    label1.Text = recognition.User?.Name;
                    label2.Text = recognition.Prediction.Distance.ToString();
                    buttonEnter.Visible = true;
                }
            }));
        }

        private void imgCamUser_Click(object sender, EventArgs e)
        {
            RecognitionSingleton.ChooseFace((image, face) =>
            {
                _lockCam = true;
                RecognitionSingleton.VideoFeed.Pause();
                Recognize(image, face);
                btnClear.Visible = true;
            });
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _lockCam = false;
            RecognitionSingleton.VideoFeed.Start();
            btnClear.Invoke(new MethodInvoker(() => btnClear.Visible = false));
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            var form = new MenuForm(_lastRecognition?.User);
            form.ShowDialog();
        }
    }
}
