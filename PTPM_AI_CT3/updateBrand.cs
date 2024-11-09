using System;
using System.Windows.Forms;
using DTO;
using BLL;

namespace PTPM_AI_CT3
{
    public partial class updateBrand : UserControl
    {
        BrandBLL brandbll = new BrandBLL();

        public event EventHandler BrandUpdated;

        public updateBrand()
        {
            InitializeComponent();
            this.button1.Click += Button1_Click;
            this.button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string brandId = textBoxID.Text;
            string brandName = textBoxName.Text;
            string brandAddress = textBoxAddress.Text;
            string brandPhone = textBoxPhone.Text;

            if (brandbll.updateBrand(brandId, brandName, brandAddress, brandPhone))
            {
                MessageBox.Show("Update thành công");
            }
            else
            {
                MessageBox.Show("Update thất bại");
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
