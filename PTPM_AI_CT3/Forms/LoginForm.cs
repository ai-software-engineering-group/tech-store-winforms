using BLL;
using DTO;
using PTPM_AI_CT3.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTPM_AI_CT3.Forms
{
    public partial class LoginForm : Form
    {
        private UserBLL bll;

        public LoginForm()
        {
            InitializeComponent();

            bll = new UserBLL();

            pictureBox1.BackColor = Color.FromArgb(243, 240, 250);
            btnLogin.BackColor = Color.FromArgb(41, 98, 255);

            lblCancel.Click += LblCancel_Click;
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Texts;
            string password = txtPassword.Texts;

            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            User user = bll.GetUser(userName, password);
            if(user == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(user.RoleId != "admin")
            {
                MessageBox.Show("Tài khoản không có quyền truy cập", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AuthenticatedUser.SetAuthenticatedUser(user);
            this.Hide();

            if(user.FirstLogin == true)
            {
                new ChangePasswordForm().Show();
            }
            else
            {
                new MainForm().Show();
            }
        }

        private void LblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
