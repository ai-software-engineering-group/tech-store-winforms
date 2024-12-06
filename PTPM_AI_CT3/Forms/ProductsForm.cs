using BLL;
using DTO;
using PTPM_AI_CT3.Constants;
using PTPM_AI_CT3.Utils;
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
        PagedList<Product> products;

        private int currentPage = 1;
        private int pageSize = 20;

        private int index = 1;

        public ProductsForm()
        {
            InitializeComponent();

            bll = new ProductBLL();

            this.Load += ProductsForm_Load;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            initUI();
            LoadProducts(null);
        }

        private void initUI()
        {
            btnAddProduct.BackColor = MyColors.GREEN;
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Click += BtnAddProduct_Click;
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadProducts(txtSearch.Text);
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
            txtSearch.Clear();
            products = bll.GetProducts(currentPage, pageSize);
            RenderProducts(products.Items);
        }

        private void LoadProducts(string searchText)
        {
            if(string.IsNullOrEmpty(searchText))
            {
                products = bll.GetProducts(currentPage, pageSize);
            }
            else
            {
                products = bll.SearchProducts(currentPage, pageSize, searchText);
            }

            currentPage = products.CurrentPage;

            PaginateUtils.RenderPaginateButtons(currentPage, products.TotalPages, panelPagination, PaginateUtils_OnPageClick);
            RenderProducts(products.Items);

        }

        private void PaginateUtils_OnPageClick(object sender, EventArgs e)
        {
            if (sender is int pageNumber)
            {
                currentPage = pageNumber;
                LoadProducts(txtSearch.Text);
            }

        }

        private void RenderProducts(IEnumerable<Product> data)
        {
            panelProducts.Controls.Clear();

            int height = 0;

            index = (currentPage - 1) * pageSize + 1;

            foreach(Product product in data)
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
                    Product productToDelete = bll.GetProductById(product.ProductId);

                    if (productToDelete == null)
                    {
                        MessageBox.Show("Sản phẩm không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (product.WarehouseProducts.Count > 0)
                    {
                        MessageBox.Show("Sản phẩm đã được nhập vào kho, không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (product.WarehouseImportDetails.Count > 0)
                    {
                        MessageBox.Show("Sản phẩm đã được nhập vào kho, không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (product.WarehouseExportDetails.Count > 0)
                    {
                        MessageBox.Show("Sản phẩm đã được xuất kho và lưu trong phiếu xuất, không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    if (product.InvoiceDetails.Count > 0)
                    {
                        MessageBox.Show("Sản phẩm đã được bán và lưu trong hóa đơn, không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool result = bll.DeleteProduct(product.ProductId);
                        if (result)
                        {
                            LoadProducts(txtSearch.Text);
                        }
                        else
                        {
                            MessageBox.Show("Xóa sản phẩm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                });

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
