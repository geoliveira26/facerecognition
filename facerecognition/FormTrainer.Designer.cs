namespace facerecognition
{
    partial class FormTrainer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imgUserCam = new Emgu.CV.UI.ImageBox();
            this.buttonRecognize = new System.Windows.Forms.Button();
            this.image1 = new Emgu.CV.UI.ImageBox();
            this.image2 = new Emgu.CV.UI.ImageBox();
            this.image3 = new Emgu.CV.UI.ImageBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgUserCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image3)).BeginInit();
            this.SuspendLayout();
            // 
            // imgUserCam
            // 
            this.imgUserCam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgUserCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgUserCam.Location = new System.Drawing.Point(134, 54);
            this.imgUserCam.Name = "imgUserCam";
            this.imgUserCam.Size = new System.Drawing.Size(319, 243);
            this.imgUserCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgUserCam.TabIndex = 2;
            this.imgUserCam.TabStop = false;
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.Enabled = false;
            this.buttonRecognize.Location = new System.Drawing.Point(303, 12);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(150, 36);
            this.buttonRecognize.TabIndex = 3;
            this.buttonRecognize.Text = "buttonRecognize";
            this.buttonRecognize.UseVisualStyleBackColor = true;
            this.buttonRecognize.Click += new System.EventHandler(this.buttonRecognize_Click);
            // 
            // image1
            // 
            this.image1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image1.Location = new System.Drawing.Point(11, 54);
            this.image1.Name = "image1";
            this.image1.Size = new System.Drawing.Size(117, 77);
            this.image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image1.TabIndex = 4;
            this.image1.TabStop = false;
            // 
            // image2
            // 
            this.image2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image2.Location = new System.Drawing.Point(11, 137);
            this.image2.Name = "image2";
            this.image2.Size = new System.Drawing.Size(117, 77);
            this.image2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image2.TabIndex = 5;
            this.image2.TabStop = false;
            // 
            // image3
            // 
            this.image3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image3.Location = new System.Drawing.Point(11, 220);
            this.image3.Name = "image3";
            this.image3.Size = new System.Drawing.Size(117, 77);
            this.image3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image3.TabIndex = 6;
            this.image3.TabStop = false;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(11, 27);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(286, 20);
            this.textName.TabIndex = 7;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(11, 8);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Nome";
            // 
            // FormTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 309);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.image3);
            this.Controls.Add(this.image2);
            this.Controls.Add(this.image1);
            this.Controls.Add(this.buttonRecognize);
            this.Controls.Add(this.imgUserCam);
            this.Name = "FormTrainer";
            this.Text = "FormTrainer";
            ((System.ComponentModel.ISupportInitialize)(this.imgUserCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgUserCam;
        private System.Windows.Forms.Button buttonRecognize;
        private Emgu.CV.UI.ImageBox image1;
        private Emgu.CV.UI.ImageBox image2;
        private Emgu.CV.UI.ImageBox image3;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelName;
    }
}