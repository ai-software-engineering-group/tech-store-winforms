namespace PTPM_AI_CT3.Forms
{
    partial class ChangePasswordForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangePassword = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOldPassword = new UserControls.MyTextbox();
            this.txtNewPassword = new UserControls.MyTextbox();
            this.txtConfNewPassword = new UserControls.MyTextbox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(47, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đây là lần đầu bạn đăng nhập. Vui lòng đổi mật khẩu mới.";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnChangePassword.IconColor = System.Drawing.Color.Black;
            this.btnChangePassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChangePassword.IconSize = 18;
            this.btnChangePassword.Location = new System.Drawing.Point(259, 250);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(110, 30);
            this.btnChangePassword.TabIndex = 1;
            this.btnChangePassword.Text = "Xác nhận";
            this.btnChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangePassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật khẩu cũ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu mới";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nhập lại mật khẩu mới";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.IsPasswordChar = true;
            this.txtOldPassword.Location = new System.Drawing.Point(59, 86);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtOldPassword.PlaceholderText = "";
            this.txtOldPassword.Size = new System.Drawing.Size(310, 27);
            this.txtOldPassword.TabIndex = 8;
            this.txtOldPassword.Texts = "";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.IsPasswordChar = true;
            this.txtNewPassword.Location = new System.Drawing.Point(59, 143);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtNewPassword.PlaceholderText = "";
            this.txtNewPassword.Size = new System.Drawing.Size(310, 27);
            this.txtNewPassword.TabIndex = 9;
            this.txtNewPassword.Texts = "";
            // 
            // txtConfNewPassword
            // 
            this.txtConfNewPassword.IsPasswordChar = true;
            this.txtConfNewPassword.Location = new System.Drawing.Point(59, 203);
            this.txtConfNewPassword.Name = "txtConfNewPassword";
            this.txtConfNewPassword.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtConfNewPassword.PlaceholderText = "";
            this.txtConfNewPassword.Size = new System.Drawing.Size(310, 27);
            this.txtConfNewPassword.TabIndex = 10;
            this.txtConfNewPassword.Texts = "";
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(431, 323);
            this.Controls.Add(this.txtConfNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnChangePassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private UserControls.MyTextbox txtOldPassword;
        private UserControls.MyTextbox txtNewPassword;
        private UserControls.MyTextbox txtConfNewPassword;
    }
}