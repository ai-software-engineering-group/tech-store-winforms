using BLL;
using DTO;
using PTPM_AI_CT3.Constants;
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

        private int currentPage = 1;
        private int pageSize = 20;

        public ProductsForm()
        {
            InitializeComponent();

            bll = new ProductBLL();

            this.Load += ProductsForm_Load;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            initUI();
            loadProducts();
        }

        private void initUI()
        {
            btnAddProduct.BackColor = MyColors.GREEN;
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Click += BtnAddProduct_Click;
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddUpdateProductForm form = new AddUpdateProductForm(false, null);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.OnLoadProducts += OnLoadProductsEvent;
            form.ShowDialog();
        }

        private void OnLoadProductsEvent(object sender, EventArgs e)
        {
            loadProducts();
        }

        private void loadProducts()
        {
            panelProducts.Controls.Clear();
            products = bll.GetProducts();

            int index = 1;
            int height = 0;

            foreach(Product product in products)
            {
                ProductListItem item = new ProductListItem(product, index);
                item.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                item.Top = height;
                item.Width = panelProducts.ClientSize.Width;

                item.SetClickEvent((s, e) =>
                {
                    AddUpdateProductForm form = new AddUpdateProductForm(true, product.ProductId);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.ShowDialog();
                }, (s, e) =>
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //bll.DeleteProduct(product.ProductId);
                        panelProducts.Controls.Remove(item);
                    }
                });

                height += item.Height;
                index++;

                panelProducts.Controls.Add(item);
            }

            //loadProductImages();
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
