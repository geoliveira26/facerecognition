﻿using Emgu.CV;
using Emgu.CV.Structure;
using facerecognition.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace facerecognition
{
    public partial class FormTrainer : Form
    {
        private bool _recognitionComplete = false;
        private Image<Gray, byte> _camFace;
        private Image<Gray, byte> _recognizedFace;
        private RecognitionService _recognitionService;

        public FormTrainer()
        {
            InitializeComponent();

            Load += (s, a) => RecognitionSingleton.VideoFeed.OnFaceDetected(OnFaceDetected);
            FormClosing += (s, a) => RecognitionSingleton.VideoFeed.ClearEvents();

            _recognitionService = new RecognitionService();
        }

        private void SetFace(Image<Gray, byte> image)
        {
            image1.Invoke(new MethodInvoker(() => image1.Image = image));
            _recognitionComplete = true;
            _recognizedFace = image;
            buttonRecognize.Invoke(new MethodInvoker(() =>
            {
                buttonRecognize.Enabled = true;
                buttonRecognize.BackColor = Color.Green;
                buttonRecognize.Text = "Salvar reconhecimento";
            }));
        }

        private void buttonRecognize_Click(object sender, EventArgs e)
        {
            if (!_recognitionComplete)
            {
                SetFace(_camFace);
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

        private void CloseForm()
        {
            Hide();
            var form = new FormDetector();
            form.ShowDialog();
            Close();
        }
        
        public void OnFaceDetected(Image<Bgr, byte> image, Image<Bgr, byte> originalImage, Image<Gray, byte> face)
        {
            buttonRecognize.Invoke(new MethodInvoker(() =>
            {
                imgUserCam.Image = image;
                if (_recognitionComplete)
                    return;

                _camFace = face != null ? face : _recognizedFace;
                buttonRecognize.Enabled = face != null;
                buttonRecognize.BackColor = face != null ? Color.Blue : Color.Red;
                buttonRecognize.Text = face != null ? "Guardar reconhecimento" : "Face não reconhecida";
            }));
        }

        private void FormTrainer_Load(object sender, EventArgs e)
        {

        }

        private void imgUserCam_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var image = new Image<Gray, byte>(dlg.FileName);
                    var face = RecognitionSingleton.GetFace(image);
                    if (face == null)
                    {
                        MessageBox.Show("Nenhuma face detectada");
                        return;
                    }

                    SetFace(face);
                }
            }
        }
    }
}