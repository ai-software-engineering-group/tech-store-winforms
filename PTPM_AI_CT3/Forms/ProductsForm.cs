using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControls;

namespace PTPM_AI_CT3.Forms
{
    public partial class ProductsForm : Form
    {
        ProductBLL bll;
        IEnumerable<Product> products;

        public ProductsForm()
        {
            InitializeComponent();

            bll = new ProductBLL();

            this.Load += ProductsForm_Load;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            loadProducts();
        }

        private void loadProducts()
        {
            products = bll.GetProducts();

            int index = 1;
            int height = 0;

            foreach(Product product in products)
            {
                ProductListItem item = new ProductListItem(product, index);
                item.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                item.Top = height;
                item.Width = panelProducts.ClientSize.Width;

                height += item.Height;
                index++;

                panelProducts.Controls.Add(item);
            }

            loadProductImages();
        }

        private async void loadProductImages()
        {
            List<ProductListItem> items = panelProducts.Controls.OfType<ProductListItem>().ToList();

            foreach (ProductListItem item in items) { 
                await item.loadImageFromUrl();
            }
        }
    }
}
