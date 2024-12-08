using BLL;
using DTO;
using PTPM_AI_CT3.Auth;
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

namespace PTPM_AI_CT3.Forms
{
    public partial class WarehouseImportForm : Form
    {
        private WarehouseBLL warehouseBll = new WarehouseBLL();
        private ProductBLL productBll = new ProductBLL();
        private SupplierBLL supplierBll = new SupplierBLL();

        List<WarehouseImportDetail> importDetails = new List<WarehouseImportDetail>();

        public WarehouseImportForm()
        {
            InitializeComponent();

            btnSubmit.BackColor = MyColors.GREEN;

            this.Load += WarehouseImportForm_Load;
        }

        private void WarehouseImportForm_Load(object sender, EventArgs e)
        {
            if(!AuthenticatedUser.IsAuthenticated || AuthenticatedUser.Employee == null)
            {
                MessageBox.Show("Bạn cần đăng nhập để sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            cbbWarehouses.DataSource = warehouseBll.GetWareHouse();
            cbbWarehouses.DisplayMember = nameof(Warehouse.WarehouseName);
            cbbWarehouses.ValueMember = nameof(Warehouse.WarehouseId);

            cbbSupplier.DataSource = supplierBll.GetSuppliers();
            cbbSupplier.DisplayMember = nameof(Supplier.SupplierName);
            cbbSupplier.ValueMember = nameof(Supplier.SupplierId);

            txtSlipId.Text = DateTime.Now.ToString("yyyyMMdd") + RandomUtils.GenerateRandomString(8).ToUpper();
            txtDateCreate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            txtDateImport.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            txtEmployeeName.Text = AuthenticatedUser.Employee.EmployeeName;

            InitUI();
        }

        private void InitUI()
        {
            btnSearch.Click += BtnSearch_Click;

            dgvSearchedProduct.Columns.Add(nameof(Product.ProductId), "Mã sản phẩm");
            dgvSearchedProduct.Columns.Add(nameof(Product.ProductName), "Tên sản phẩm");
            dgvSearchedProduct.Columns.Add(nameof(Product.Price), "Giá bán");
            dgvSearchedProduct.Columns.Add(nameof(Product.Brand.BrandName), "Hãng sản xuất");
            dgvSearchedProduct.Columns.Add(nameof(Product.Category.CategoryName), "Danh mục");

            DataGridViewButtonColumn selectButtonColumn = new DataGridViewButtonColumn
            {
                Name = "SelectButton",
                HeaderText = "",
                Text = "Chọn",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvSearchedProduct.Columns.Add(selectButtonColumn);
            dgvSearchedProduct.CellContentClick += DgvSearchedProduct_CellContentClick;

            //
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "DeleteButton",
                HeaderText = "",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvImportDetails.Columns.Add(deleteButtonColumn);

            dgvImportDetails.CellContentClick += DgvImportDetails_CellContentClick;

            //
            btnSubmit.Click += BtnSubmit_Click;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string slipId = txtSlipId.Text;
            DateTime dateImport = DateTime.Parse(txtDateImport.Text);
            DateTime createDate = DateTime.Parse(txtDateCreate.Text);

            string supplierId = cbbSupplier.SelectedValue.ToString();
            string warehouseId = cbbWarehouses.SelectedValue.ToString();

            if(string.IsNullOrEmpty(supplierId) || string.IsNullOrEmpty(warehouseId))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp và kho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(importDetails.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm nhập kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            WarehouseImport warehouseImport = new WarehouseImport
            {
                WIId = slipId,
                DateImport = dateImport,
                DateCreate = createDate,
                SupplierId = supplierId,
                WarehouseId = warehouseId,
                EmployeeId = AuthenticatedUser.Employee.EmployeeId,
            };

            warehouseImport.WarehouseImportDetails.AddRange(importDetails);

            bool result = warehouseBll.CreateImportSlip(warehouseImport);

            if(result)
            {
                MessageBox.Show("Nhập kho thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nhập kho thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            List<Product> result = productBll.SearchProducts(txtSearch.Text);

            dgvSearchedProduct.Rows.Clear();
            foreach (var product in result)
            {
                dgvSearchedProduct.Rows
                    .Add(product.ProductId, product.ProductName, product.Price.ToString("##.###") + "đ", product.Brand.BrandName, product.Category.CategoryName);
            }
        }

        private void DgvSearchedProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSearchedProduct.Columns[e.ColumnIndex].Name != "SelectButton")
            {
                return;
            }

            var selectedRow = dgvSearchedProduct.Rows[e.RowIndex];
            string productId = selectedRow.Cells[nameof(Product.ProductId)].Value.ToString();
            string productName = selectedRow.Cells[nameof(Product.ProductName)].Value.ToString();
            string brandName = selectedRow.Cells[nameof(Product.Brand.BrandName)].Value.ToString();
            string categoryName = selectedRow.Cells[nameof(Product.Category.CategoryName)].Value.ToString();

            if(productId == null)
            {
                return;
            }

            if(importDetails.Any(d => d.ProductId == productId))
            {
                MessageBox.Show("Sản phẩm đã được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            importDetails.Add(new WarehouseImportDetail
            {
                ProductId = productId,
                Quantity = 1,
                UnitPrice = 0
            });

            LoadGridViewImportDetails();

            UpdateTotalPrice();
        }

        private void LoadGridViewImportDetails()
        {
            dgvImportDetails.DataSource = null;
            dgvImportDetails.DataSource = importDetails;

            //////////////////////////////
            dgvImportDetails.Columns[nameof(WarehouseImportDetail.ProductId)].HeaderText = "Mã sản phẩm";
            dgvImportDetails.Columns[nameof(WarehouseImportDetail.Quantity)].HeaderText = "Số lượng";
            dgvImportDetails.Columns[nameof(WarehouseImportDetail.UnitPrice)].HeaderText = "Giá nhập";

            dgvImportDetails.Columns[nameof(WarehouseImportDetail.ProductId)].ReadOnly = true;
            dgvImportDetails.Columns[nameof(WarehouseImportDetail.Product)].Visible = false;
            dgvImportDetails.Columns[nameof(WarehouseImportDetail.WarehouseImport)].Visible = false;
            dgvImportDetails.Columns[nameof(WarehouseImportDetail.WIId)].Visible = false;
            dgvImportDetails.Columns[nameof(WarehouseImportDetail.Id)].Visible = false;

            //
            dgvImportDetails.Columns["DeleteButton"].DisplayIndex = dgvImportDetails.Columns.Count - 1;
            dgvImportDetails.CellEndEdit += DgvImportDetails_CellEndEdit;
        }

        private void UpdateTotalPrice()
        {
            decimal totalPrice = importDetails
               .Sum(d => d.Quantity * d.UnitPrice);
            lblTotalPrice.Text = totalPrice > 0 ? totalPrice.ToString("##.###") : "0" + "đ";
        }

        private void DgvImportDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvImportDetails.Columns[e.ColumnIndex].Name != "DeleteButton")
            {
                return;
            }

            var selectedRow = dgvImportDetails.Rows[e.RowIndex];
            string productId = selectedRow.Cells[nameof(Product.ProductId)].Value.ToString();

            if (productId == null)
            {
                return;
            }

            importDetails.RemoveAll(d => d.ProductId == productId);

            LoadGridViewImportDetails();

            UpdateTotalPrice();
        }

        private void DgvImportDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            string productId = dgvImportDetails.Rows[rowIndex].Cells[nameof(WarehouseImportDetail.ProductId)].Value.ToString();
            string quantity = dgvImportDetails.Rows[rowIndex].Cells[nameof(WarehouseImportDetail.Quantity)].Value.ToString();
            string unitPrice = dgvImportDetails.Rows[rowIndex].Cells[nameof(WarehouseImportDetail.UnitPrice)].Value.ToString();

            if (string.IsNullOrEmpty(productId) || string.IsNullOrEmpty(quantity) || string.IsNullOrEmpty(unitPrice))
            {
                return;
            }

            if (!int.TryParse(quantity, out int quantityValue) || !decimal.TryParse(unitPrice, out decimal unitPriceValue))
            {
                MessageBox.Show("Số lượng hoặc giá nhập không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var importDetail = importDetails.FirstOrDefault(d => d.ProductId == productId);
            if (importDetail != null)
            {
                importDetail.Quantity = quantityValue;
                importDetail.UnitPrice = unitPriceValue;
            }

            UpdateTotalPrice();
        }
    }
}
