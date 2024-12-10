using System;
using System.Windows.Forms;
using DTO;
using BLL;

namespace UserControls
{
    public partial class updateBrand : UserControl
    {
        BrandBLL brandbll = new BrandBLL();
        private string brandId;

        public event EventHandler BrandUpdated;

        public updateBrand(string brandId)
        {
            InitializeComponent();
            this.button1.Click += Button1_Click;
            this.button2.Click += Button2_Click;
            this.brandId = brandId;

            this.Load += UpdateBrand_Load;
        }

        private void UpdateBrand_Load(object sender, EventArgs e)
        {
            textBoxID.Enabled = false;

            Brand brand = brandbll.find_brand(brandId);
            textBoxID.Text = brand.BrandId;
            textBoxName.Text = brand.BrandName;
            textBoxAddress.Text = brand.Address;
            textBoxPhone.Text = brand.Phone;
            textBoxLogo.Text = brand.LogoSrc;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string brandId = textBoxID.Text;
            string brandName = textBoxName.Text;
            string brandAddress = textBoxAddress.Text;
            string brandPhone = textBoxPhone.Text;
            string brandLogo = textBoxLogo.Text;

            if (brandbll.updateBrand(brandId, brandName, brandAddress, brandPhone,brandLogo))
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
