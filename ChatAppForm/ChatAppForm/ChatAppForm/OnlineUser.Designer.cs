namespace ChatAppForm
{
    partial class OnlineUser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUserName = new System.Windows.Forms.Label();
            this.rbMuteUser = new System.Windows.Forms.RadioButton();
            this.userPicture = new ChatAppForm.OvalPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.userPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUserName.Location = new System.Drawing.Point(84, 23);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(75, 21);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "John Doe";
            // 
            // rbMuteUser
            // 
            this.rbMuteUser.AutoSize = true;
            this.rbMuteUser.Location = new System.Drawing.Point(13, 27);
            this.rbMuteUser.Name = "rbMuteUser";
            this.rbMuteUser.Size = new System.Drawing.Size(14, 13);
            this.rbMuteUser.TabIndex = 1;
            this.rbMuteUser.TabStop = true;
            this.rbMuteUser.UseVisualStyleBackColor = true;
            // 
            // userPicture
            // 
            this.userPicture.BackColor = System.Drawing.Color.DarkGray;
            this.userPicture.Location = new System.Drawing.Point(33, 12);
            this.userPicture.Name = "userPicture";
            this.userPicture.Size = new System.Drawing.Size(45, 45);
            this.userPicture.TabIndex = 2;
            this.userPicture.TabStop = false;
            // 
            // OnlineUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.Controls.Add(this.userPicture);
            this.Controls.Add(this.rbMuteUser);
            this.Controls.Add(this.lblUserName);
            this.Name = "OnlineUser";
            this.Size = new System.Drawing.Size(253, 69);
            ((System.ComponentModel.ISupportInitialize)(this.userPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.RadioButton rbMuteUser;
        private OvalPictureBox userPicture;
    }
}
