namespace facerecognition
{
    partial class FormDetector
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
            this.imgCamUser = new Emgu.CV.UI.ImageBox();
            this.buttonNewRecognition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).BeginInit();
            this.SuspendLayout();
            // 
            // imgCamUser
            // 
            this.imgCamUser.Location = new System.Drawing.Point(12, 12);
            this.imgCamUser.Name = "imgCamUser";
            this.imgCamUser.Size = new System.Drawing.Size(458, 303);
            this.imgCamUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCamUser.TabIndex = 2;
            this.imgCamUser.TabStop = false;
            this.imgCamUser.Click += new System.EventHandler(this.imgCamUser_Click);
            // 
            // buttonNewRecognition
            // 
            this.buttonNewRecognition.Location = new System.Drawing.Point(476, 285);
            this.buttonNewRecognition.Name = "buttonNewRecognition";
            this.buttonNewRecognition.Size = new System.Drawing.Size(184, 30);
            this.buttonNewRecognition.TabIndex = 3;
            this.buttonNewRecognition.Text = "Reconhecer nova face";
            this.buttonNewRecognition.UseVisualStyleBackColor = true;
            this.buttonNewRecognition.Click += new System.EventHandler(this.buttonNewRecognition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "N";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(488, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "0";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(476, 105);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(184, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Limpar reconhecimento";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Erro:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nome:";
            // 
            // FormDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 329);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonNewRecognition);
            this.Controls.Add(this.imgCamUser);
            this.Name = "FormDetector";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgCamUser;
        private System.Windows.Forms.Button buttonNewRecognition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

