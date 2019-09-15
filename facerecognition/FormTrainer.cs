using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using facerecognition.Components;
using facerecognition.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace facerecognition
{
    public partial class FormTrainer : Form
    {
        private bool _recognitionComplete = false;
        private Image<Gray, byte> _recognizedImage;
        private List<Image<Gray, byte>> _recognizedFaces = new List<Image<Gray, byte>>();
        private VideoFeed _videoFeed;
        private RecognitionService _recognitionService;

        public FormTrainer()
        {
            InitializeComponent();

            Load += (s, a) => RecognitionSingleton.VideoFeed.OnFaceDetected(OnFaceDetected);
            FormClosing += (s, a) => RecognitionSingleton.VideoFeed.ClearEvents();

            _recognitionService = new RecognitionService();
        }

        private void FillPicture(Image<Gray, byte> image)
        {
            Action<ImageBox> setImage = (imageBox) => imageBox.Invoke(new MethodInvoker(() => imageBox.Image = image));

            if(image1.Image == null)
                setImage(image1);
            else if (image2.Image == null)
                setImage(image2);
            else
            {
                setImage(image3);
                _recognitionComplete = true;

                buttonRecognize.Invoke(new MethodInvoker(() =>
                {
                    buttonRecognize.Enabled = true;
                    buttonRecognize.BackColor = Color.Green;
                    buttonRecognize.Text = "Salvar reconhecimento";
                }));
            }
        }

        private void buttonRecognize_Click(object sender, EventArgs e)
        {
            if (_recognitionComplete)
            {
                if (string.IsNullOrWhiteSpace(textName.Text))
                {
                    MessageBox.Show("Preencha o nome");
                    return;
                }

                var user = new User(textName.Text, _recognizedFaces);
                Connection.InsertUser(user);
                _recognitionService.AddUser(user);
                CloseForm();
                return;
            }

            FillPicture(_recognizedImage);
            _recognizedFaces.Add(_recognizedImage);
        }

        private void CloseForm()
        {
            Hide();
            var form = new FormDetector();
            form.ShowDialog();
            Close();
        }
        

        public void OnFaceDetected(Image<Bgr, byte> image, Image<Bgr, byte> originalImage, List<Image<Gray, byte>> faces)
        {
            buttonRecognize.Invoke(new MethodInvoker(() =>
            {
                imgUserCam.Image = image;
                if (_recognitionComplete)
                    return;

                _recognizedImage = faces.Any() ? faces.First() : _recognizedImage;
                buttonRecognize.Enabled = faces.Any();
                buttonRecognize.BackColor = faces.Any() ? Color.Blue : Color.Red;
                buttonRecognize.Text = faces.Any() ? "Guardar reconhecimento" : "Face não reconhecida";
            }));
        }
    }
}