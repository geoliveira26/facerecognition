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
            this.textName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.radioGovernador = new System.Windows.Forms.RadioButton();
            this.radioPrefeito = new System.Windows.Forms.RadioButton();
            this.radioPresidente = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgUserCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image1)).BeginInit();
            this.SuspendLayout();
            // 
            // imgUserCam
            // 
            this.imgUserCam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgUserCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgUserCam.Location = new System.Drawing.Point(15, 181);
            this.imgUserCam.Name = "imgUserCam";
            this.imgUserCam.Size = new System.Drawing.Size(319, 243);
            this.imgUserCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgUserCam.TabIndex = 2;
            this.imgUserCam.TabStop = false;
            this.imgUserCam.Click += new System.EventHandler(this.imgUserCam_Click);
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.Enabled = false;
            this.buttonRecognize.Location = new System.Drawing.Point(183, 13);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(151, 36);
            this.buttonRecognize.TabIndex = 3;
            this.buttonRecognize.Text = "buttonRecognize";
            this.buttonRecognize.UseVisualStyleBackColor = true;
            this.buttonRecognize.Click += new System.EventHandler(this.buttonRecognize_Click);
            // 
            // image1
            // 
            this.image1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image1.Location = new System.Drawing.Point(110, 73);
            this.image1.Name = "image1";
            this.image1.Size = new System.Drawing.Size(117, 86);
            this.image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image1.TabIndex = 4;
            this.image1.TabStop = false;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(11, 27);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(166, 20);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Face reconhecida:";
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(233, 72);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(101, 86);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Resetar";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // radioGovernador
            // 
            this.radioGovernador.AutoSize = true;
            this.radioGovernador.Checked = true;
            this.radioGovernador.Location = new System.Drawing.Point(20, 70);
            this.radioGovernador.Name = "radioGovernador";
            this.radioGovernador.Size = new System.Drawing.Size(81, 17);
            this.radioGovernador.TabIndex = 11;
            this.radioGovernador.TabStop = true;
            this.radioGovernador.Text = "Governador";
            this.radioGovernador.UseVisualStyleBackColor = true;
            // 
            // radioPrefeito
            // 
            this.radioPrefeito.AutoSize = true;
            this.radioPrefeito.Location = new System.Drawing.Point(20, 98);
            this.radioPrefeito.Name = "radioPrefeito";
            this.radioPrefeito.Size = new System.Drawing.Size(61, 17);
            this.radioPrefeito.TabIndex = 12;
            this.radioPrefeito.Text = "Prefeito";
            this.radioPrefeito.UseVisualStyleBackColor = true;
            // 
            // radioPresidente
            // 
            this.radioPresidente.AutoSize = true;
            this.radioPresidente.Location = new System.Drawing.Point(20, 131);
            this.radioPresidente.Name = "radioPresidente";
            this.radioPresidente.Size = new System.Drawing.Size(75, 17);
            this.radioPresidente.TabIndex = 13;
            this.radioPresidente.Text = "Presidente";
            this.radioPresidente.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(11, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 105);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acesso";
            // 
            // FormTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 436);
            this.Controls.Add(this.radioPresidente);
            this.Controls.Add(this.radioPrefeito);
            this.Controls.Add(this.radioGovernador);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.image1);
            this.Controls.Add(this.buttonRecognize);
            this.Controls.Add(this.imgUserCam);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormTrainer";
            this.Text = "FormTrainer";
            this.Load += new System.EventHandler(this.FormTrainer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgUserCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgUserCam;
        private System.Windows.Forms.Button buttonRecognize;
        private Emgu.CV.UI.ImageBox image1;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton radioGovernador;
        private System.Windows.Forms.RadioButton radioPrefeito;
        private System.Windows.Forms.RadioButton radioPresidente;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}