using DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using ImageMagick;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

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

        public void SetClickEvent(EventHandler editEvent, EventHandler deleteEvent)
        {
            btnEditProduct.Click += editEvent;
            btnDeleteProduct.Click += deleteEvent;
        }

        private void ProductListItem_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void initUI()
        {
            btnEditProduct.IconColor = Color.FromArgb(255, 255, 255);
            btnEditProduct.BackColor = Color.FromArgb(0, 192, 246);
            btnDeleteProduct.IconColor = Color.FromArgb(255, 255, 255);
            btnDeleteProduct.BackColor = Color.FromArgb(227, 0, 25);
        }

        private void LoadData()
        {
            int instock = product.WarehouseProducts.Sum(w => w.Quantity);

            btnEditProduct.Tag = product.ProductId;
            btnDeleteProduct.Tag = product.ProductId;

            lblNo.Text = index.ToString();
            lblProductName.Text = product.ProductName;
            lblPrice.Text = product.Price.ToString("##,###") + "đ";
            lblOriginalPrice.Text = product.OriginalPrice == null ? "--" : product.OriginalPrice?.ToString("##,###") + "đ";
            lblInstock.Text = instock.ToString();

            if(instock == 0)
            {
                lblInstock.ForeColor = Color.FromArgb(227, 0, 25);
            }
        }

        public async Task loadImageFromUrl()
        {
            try
            {
                string url = product.ProductImages.FirstOrDefault().ImageSrc;

                using (HttpClient client = new HttpClient())
                {
                    var imageBytes = await client.GetByteArrayAsync(url);
                    using (var memoryStream = new MemoryStream(imageBytes))
                    {
                        using (var magickImage = new MagickImage(memoryStream))
                        {
                            using(var ms = new MemoryStream())
                            {
                                magickImage.Write(ms, MagickFormat.Png);
                                productImage.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
