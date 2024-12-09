using BLL;
using PTPM_AI_CT3.Auth;
using PTPM_AI_CT3.Constants;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PTPM_AI_CT3.Forms
{
    public partial class ChangePasswordForm : Form
    {
        UserBLL bll = new UserBLL();

        public ChangePasswordForm()
        {
            InitializeComponent();

            btnChangePassword.BackColor = MyColors.GREEN;
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Click += BtnChangePassword_Click;
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Texts;
            string newPassword = txtNewPassword.Texts;
            string confirmPassword = txtConfNewPassword.Texts;

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = AuthenticatedUser.User.Username;
            var user = bll.GetUser(username, oldPassword);

            if (user == null)
            {
                MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool result = bll.ChangePassword(username, newPassword);
            if (result)
            { 
                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                new MainForm().Show();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
