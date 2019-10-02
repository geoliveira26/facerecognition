using Emgu.CV;
using Emgu.CV.Structure;
using facerecognition.Components;
using facerecognition.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace facerecognition
{
    public partial class FormTrainer : Form
    {
        private bool _recognitionComplete = false;
        private Image<Bgr, byte> _originalImage;
        private Image<Gray, byte> _camFace;
        private Image<Gray, byte> _recognizedFace;
        private RecognitionService _recognitionService;

        public FormTrainer()
        {
            InitializeComponent();

            Load += (s, a) => RecognitionSingleton.VideoFeed.Subscribe(OnFaceDetected);
            FormClosing += (s, a) => RecognitionSingleton.VideoFeed.Unsubscribe(OnFaceDetected);

            _recognitionService = new RecognitionService();
        }

        private void SetFace(Image<Bgr, byte> original, Image<Gray, byte> face)
        {
            image1.Invoke(new MethodInvoker(() => image1.Image = face));
            _recognitionComplete = true;
            btnReset.Enabled = true;
            RecognitionSingleton.VideoFeed.Pause();

            _recognizedFace = face;
            buttonRecognize.Invoke(new MethodInvoker(() =>
            {
                buttonRecognize.Enabled = true;
                buttonRecognize.BackColor = Color.Green;
                buttonRecognize.Text = "Salvar reconhecimento";
            }));

            imgUserCam.Invoke(new MethodInvoker(() => imgUserCam.Image = original));
        }

        private void buttonRecognize_Click(object sender, EventArgs e)
        {
            if (!_recognitionComplete)
            {
                SetFace(RecognitionSingleton.VideoFeed.CamImage, RecognitionSingleton.VideoFeed.LastRecognizedFace);
                return;
            }

            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                MessageBox.Show("Preencha o nome");
                return;
            }

            var user = new User(textName.Text, _recognizedFace);
            Connection.InsertUser(user);
            RecognitionSingleton.Users.Add(user);
            CloseForm();
            return;
        }

        private void CompleteRecognition()
        {
            
        }

        private void CloseForm()
        {
            Hide();
            var form = new FormDetector();
            form.ShowDialog();
            Close();
        }
        
        public void OnFaceDetected(VideoFeed feed)
        {
            if (_recognitionComplete)
                return;

            buttonRecognize.Invoke(new MethodInvoker(() =>
            {
                imgUserCam.Image = feed.CamImageWithFace ?? feed.CamImage;
                buttonRecognize.Enabled = feed.LastRecognizedFace != null;
                buttonRecognize.BackColor = feed.LastRecognizedFace != null ? Color.Blue : Color.Red;
                buttonRecognize.Text = feed.LastRecognizedFace != null ? "Guardar reconhecimento" : "Face não reconhecida";
            }));
        }

        private void FormTrainer_Load(object sender, EventArgs e)
        {

        }

        private void imgUserCam_Click(object sender, EventArgs e)
        {
            RecognitionSingleton.ChooseFace((image, face) => SetFace(image, face));
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            RecognitionSingleton.VideoFeed.Start();
            _recognitionComplete = false;
            image1.Image = null;
        }
    }
}