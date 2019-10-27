namespace facerecognition
{
    partial class MenuForm
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
            this.buttonAccess1 = new System.Windows.Forms.Button();
            this.buttonAccess2 = new System.Windows.Forms.Button();
            this.buttonAccess3 = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAccess1
            // 
            this.buttonAccess1.Location = new System.Drawing.Point(12, 83);
            this.buttonAccess1.Name = "buttonAccess1";
            this.buttonAccess1.Size = new System.Drawing.Size(182, 50);
            this.buttonAccess1.TabIndex = 0;
            this.buttonAccess1.Text = "Governador";
            this.buttonAccess1.UseVisualStyleBackColor = true;
            // 
            // buttonAccess2
            // 
            this.buttonAccess2.Location = new System.Drawing.Point(12, 139);
            this.buttonAccess2.Name = "buttonAccess2";
            this.buttonAccess2.Size = new System.Drawing.Size(182, 50);
            this.buttonAccess2.TabIndex = 1;
            this.buttonAccess2.Text = "Prefeito";
            this.buttonAccess2.UseVisualStyleBackColor = true;
            // 
            // buttonAccess3
            // 
            this.buttonAccess3.Location = new System.Drawing.Point(12, 195);
            this.buttonAccess3.Name = "buttonAccess3";
            this.buttonAccess3.Size = new System.Drawing.Size(182, 50);
            this.buttonAccess3.TabIndex = 2;
            this.buttonAccess3.Text = "Presidente";
            this.buttonAccess3.UseVisualStyleBackColor = true;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 38);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(35, 13);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "label1";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 260);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.buttonAccess3);
            this.Controls.Add(this.buttonAccess2);
            this.Controls.Add(this.buttonAccess1);
            this.Name = "MenuForm";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccess1;
        private System.Windows.Forms.Button buttonAccess2;
        private System.Windows.Forms.Button buttonAccess3;
        private System.Windows.Forms.Label lblUser;
    }
}