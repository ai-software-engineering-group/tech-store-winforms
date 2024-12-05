using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControls
{
    public partial class ProductListItem : UserControl
    {
        private Product product;
        private int index;

        public ProductListItem(Product product, int index)
        {
            InitializeComponent();

            this.product = product;
            this.index = index;

            initUI();
            this.Load += ProductListItem_Load;
        }

        private void ProductListItem_Load(object sender, EventArgs e)
        {
            initData();
        }

        private void initUI()
        {
            btnEditProduct.IconColor = Color.FromArgb(255, 255, 255);
            btnEditProduct.BackColor = Color.FromArgb(0, 192, 246);
            btnDeleteProduct.IconColor = Color.FromArgb(255, 255, 255);
            btnDeleteProduct.BackColor = Color.FromArgb(227, 0, 25);
        }

        private void initData()
        {
            int instock = product.WarehouseProducts.Sum(w => w.Quantity);

            btnEditProduct.Tag = product.ProductId;
            btnDeleteProduct.Tag = product.ProductId;

            lblNo.Text = index.ToString();
            lblProductName.Text = product.ProductName;
            lblPrice.Text = product.Price.ToString("##,###") + "đ";
            lblOriginalPrice.Text = product.OriginalPrice?.ToString("##,###") + "đ";
            lblInstock.Text = instock.ToString();

            if(instock == 0)
            {
                lblInstock.ForeColor = Color.FromArgb(227, 0, 25);
            }

            loadImageFromUrl(productImage, product.ProductImages.FirstOrDefault().ImageSrc);
        }

        private async void loadImageFromUrl(PictureBox pictureBox, string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        response.EnsureSuccessStatusCode();

                        using(var stream = await response.Content.ReadAsStreamAsync())
                        {
                            pictureBox.Image = Image.FromStream(stream);
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
