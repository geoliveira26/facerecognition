using Emgu.CV;
using Emgu.CV.Structure;
using facerecognition.Components;
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
            Load += (s, a) => RecognitionSingleton.VideoFeed.Subscribe(OnFaceDetected);
            FormClosing += (s, a) => RecognitionSingleton.VideoFeed.Unsubscribe(OnFaceDetected);

            RecognitionSingleton.VideoFeed.Start();

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
            imgCamUser.Invoke(new MethodInvoker(() => imgCamUser.Image = feed.CamImageWithFace ?? feed.CamImage));
            label1.Invoke(new MethodInvoker(() =>
            {
                var recognition = _recognitionService.RecognizeUser(feed.LastRecognizedFace);
                if (recognition == null || recognition.Prediction.Distance == 0)
                    return;

                label1.Text = recognition.User?.Name;
                label2.Text = recognition.Prediction.Distance.ToString();
            }));
        }
    }
}
