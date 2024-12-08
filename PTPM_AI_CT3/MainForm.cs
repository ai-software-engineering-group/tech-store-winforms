using FontAwesome.Sharp;
using PTPM_AI_CT3.Auth;
using PTPM_AI_CT3.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTPM_AI_CT3
{
    public partial class MainForm : Form
    {
        private struct Colors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(24, 161, 251);
            public static Color color8 = Color.FromArgb(24, 161, 251);
            public static Color color9 = Color.FromArgb(24, 161, 251);
        }

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public MainForm()
        {
            InitializeComponent();

            initUI();

            this.FormClosing += MainForm_FormClosing;
        }

        // Active sidebar button
        private void ActiveBtn(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableBtn();

                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(227, 233, 247);
                currentBtn.ForeColor = color;
                currentBtn.IconColor = color;

                leftBorderBtn.Height = currentBtn.Height;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();  
                
                titleIcon.IconChar = currentBtn.IconChar;
                titleIcon.IconColor = color;

            }
        }

        // Disable sidebar button
        private void DisableBtn()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(227, 233, 247);
                currentBtn.ForeColor = Color.Black;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Black;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void initUI()
        {
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 55);
            panelSidebar.Controls.Add(leftBorderBtn);

            panelMain.BackColor = Color.FromArgb(245, 245, 245);

            this.Load += MainForm_Load;

            btnHome.Click += BtnHome_Click;
            btnCategories.Click += BtnCategories_Click;
            btnProducts.Click += BtnProducts_Click;
            btnBrands.Click += BtnBrands_Click;
            btnOrders.Click += BtnOrders_Click;
            btnCustomers.Click += BtnCustomers_Click;
            btnEmployees.Click += BtnEmployees_Click;
            btnWarehouses.Click += BtnWarehouses_Click;
            btnWHImport.Click += BtnWHImport_Click;
            btnWHexport.Click += BtnWHexport_Click;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(!AuthenticatedUser.IsAuthenticated)
            {
                MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
        }

        private void BtnWHexport_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, Colors.color8);

        }

        private void BtnWHImport_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, Colors.color8);
            OpenChildForm(new WarehouseImportForm());
        }

        private void BtnWarehouses_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, Colors.color8);
            OpenChildForm(new WarehouseForm());
        }

        private void BtnEmployees_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, Colors.color7);
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, Colors.color6);
            OpenChildForm(new CustomerForm());
        }

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, Colors.color5);
            OpenChildForm(new InvoicesForm());
        }

        private void BtnBrands_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, Colors.color4);
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, Colors.color3);
            OpenChildForm(new ProductsForm());
        }

        private void BtnCategories_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, Colors.color2);
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            ActiveBtn(sender, Colors.color1);
        }

        private void OpenChildForm(Form form)
        {
            try
            {
                if (currentChildForm != null)
                {
                    currentChildForm.Close();
                }

                currentChildForm = form;
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                panelMain.Controls.Add(form);
                panelMain.Tag = form;
                form.BringToFront();
                form.Show();
                titleLabel.Text = form.Text;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult r = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (r == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }

        }
    }
}
