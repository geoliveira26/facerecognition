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
    public partial class FormTrainer : LiveFeedComponent
    {
        private bool _recognitionComplete = false;
        private Image<Gray, byte> _recognizedImage;
        private List<Image<Gray, byte>> _recognizedFaces = new List<Image<Gray, byte>>();
        private VideoFeed _videoFeed;
        private RecognitionService _recognitionService;

        public FormTrainer()
        {
            InitializeComponent();
            
            //_recognitionService = new RecognitionService();
        }

        private void FormTrainer_Load(object sender, EventArgs e)
        {

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
                RecognitionSingleton.Users.Add(new User(RecognitionSingleton.Users.Count + 1, _recognizedFaces));
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

        private void FormTrainer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CloseForm();
        }

        public override void OnFaceDetected(Image<Bgr, byte> image, Image<Bgr, byte> originalImage, List<Image<Gray, byte>> faces)
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