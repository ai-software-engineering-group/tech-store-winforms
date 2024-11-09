using System;
using System.Windows.Forms;
using BLL;
using DTO;

namespace PTPM_AI_CT3
{
    public partial class InsertBrand : UserControl
    {
        BrandBLL brandbll = new BrandBLL();

        public InsertBrand()
        {
            InitializeComponent();
            this.button1.Click += Button1_Click;
            this.button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Brand brand = new Brand();
            brand.BrandId = textBoxID.Text;
            brand.BrandName = textBoxName.Text;
            brand.Address = textBoxAddress.Text;
            brand.Phone = textBoxPhone.Text;

            if (brandbll.themBrand(brand))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
