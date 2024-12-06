using BLL;
using DTO;
using PTPM_AI_CT3.AzureServices;
using PTPM_AI_CT3.Constants;
using PTPM_AI_CT3.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTPM_AI_CT3.Forms
{
    public partial class AddUpdateProductForm : Form
    {
        private CategoryBLL categoryBLL;
        private BrandBLL brandBLL;
        private ProductBLL productBLL;

        private CloudStorageService azureCloud;

        private int imageCurrentRow = 0, imageCurrentCol = 0;
        private List<ProductSpecification> specs;
        List<ProductImage> images;
        List<ProductImage> oldImages;

        public bool isUpdate;
        public string productUpdateId;

        public event EventHandler OnLoadProducts;

        public AddUpdateProductForm(bool isUpdate, string productUpdateId)
        {
            InitializeComponent();

            this.isUpdate = isUpdate;
            this.productUpdateId = productUpdateId;

            categoryBLL = new CategoryBLL();
            brandBLL = new BrandBLL();
            productBLL = new ProductBLL();

            azureCloud = new CloudStorageService();

            specs = new List<ProductSpecification>();
            images = new List<ProductImage>();
            oldImages = new List<ProductImage>();


            this.Load += AddUpdateProductForm_Load;
            btnSubmit.Click += BtnSubmit_Click;
            btnUploadImages.Click += BtnUploadImages_Click;
            btnAddSpec.Click += BtnAddSpec_Click;
        }

        private void BtnAddSpec_Click(object sender, EventArgs e)
        {
            string specName = txtSpecName.Text;
            string specValue = txtSpecValue.Text;

            if (string.IsNullOrEmpty(specName) || string.IsNullOrEmpty(specValue))
            {
                MessageBox.Show("Vui lòng nhập tên và mô tả thông số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            specs.Add(new ProductSpecification
            {
                SpecName = specName,
                SpecValue = specValue
            });

            dgvSpecifications.DataSource = specs.Select(s => new
            {
                s.SpecName,
                s.SpecValue
            }).ToList();

            txtSpecName.Clear();
            txtSpecValue.Clear();
        }

        private void BtnUploadImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Image Files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"
            };

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                panelImages.Controls.Clear();
                imageCurrentCol = 0;
                imageCurrentRow = 0;

                foreach (string filePath in openFileDialog.FileNames)
                {
                    RenderImageToPanel(filePath, false);
                    images.Add(new ProductImage
                    {
                        ImageSrc = filePath,
                    });
                }
            }
        }

        private async void RenderImageToPanel(string filePath, bool fromCloud)
        {
            int margin = 15;
            int pictureBoxSize = 100;
            int panelWidth = panelImages.Width;

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(pictureBoxSize, pictureBoxSize),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = fromCloud ? await ImageUtils.LoadImageFromUrl(filePath) : Image.FromFile(filePath),
                BorderStyle = BorderStyle.FixedSingle
            };

            int columns = panelWidth / (pictureBoxSize + margin);

            pictureBox.Left = imageCurrentCol * (pictureBoxSize + margin);
            pictureBox.Top = imageCurrentRow * (pictureBoxSize + margin);

            panelImages.Controls.Add(pictureBox);

            imageCurrentCol++;
            if (imageCurrentCol >= columns)
            {
                imageCurrentCol = 0;
                imageCurrentRow++;
            }
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            bool submitResult = false;

            if (!ProcessData())
            {
                return;
            }

            if (!isUpdate)
            {
                Product existedProduct = productBLL.GetProductById(txtProductId.Text);

                if(existedProduct != null)
                {
                    MessageBox.Show($"Sản phẩm với mã {txtProductId.Text} đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Cursor = Cursors.WaitCursor;    

                Product product = GetProductFormData();

                await uploadImagesToAzure(product.ProductId, product.ProductName);

                submitResult = productBLL.AddProduct(product, images, specs);
                this.Cursor = Cursors.Default;

                if(!submitResult)
                {
                    MessageBox.Show("Không thể thêm sản phẩm, vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Product product = GetProductFormData();

                submitResult = productBLL.UpdateProduct(product, images, specs);
                this.Cursor = Cursors.Default;

                if (!submitResult)
                {
                    MessageBox.Show("Không thể cập nhật sản phẩm, vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Cập nhật sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            OnLoadProducts?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private Product GetProductFormData()
        {
            return new Product
            {
                ProductId = txtProductId.Text,
                ProductName = txtProductName.Text,
                BrandId = cbbBrands.SelectedIndex > 0 ? cbbBrands.SelectedValue.ToString() : null,
                CategoryId = cbbCategories.SelectedIndex > 0 ? cbbCategories.SelectedValue.ToString() : null,
                Price = decimal.Parse(txtPrice.Text),
                OriginalPrice = string.IsNullOrEmpty(txtOriginalPrice.Text) ? null : (decimal?)decimal.Parse(txtOriginalPrice.Text),
                ShortDescription = txtShortDescription.Text,
                Description = txtDescription.Text,
                ManufacturedYear = string.IsNullOrEmpty(txtManuYear.Text) ? null : (int?)int.Parse(txtManuYear.Text),
                Warranty = string.IsNullOrEmpty(txtWarranty.Text) ? null : (int?)int.Parse(txtWarranty.Text),
                DateAdded = DateTime.Now,
                IsActive = true,
            };
        }

        private void LoadProductFormData()
        {
            Product product = productBLL.GetProductById(productUpdateId);

            txtProductId.Text = product.ProductId;
            txtProductName.Text = product.ProductName;
            cbbBrands.SelectedValue = product.BrandId;
            cbbCategories.SelectedValue = product.CategoryId;
            txtPrice.Text = product.Price.ToString();
            txtOriginalPrice.Text = product.OriginalPrice?.ToString();
            txtShortDescription.Text = product.ShortDescription;
            txtDescription.Text = product.Description;
            txtManuYear.Text = product.ManufacturedYear?.ToString();
            txtWarranty.Text = product.Warranty?.ToString();

            foreach(ProductImage image in product.ProductImages)
            {
                images.Add(image);
                oldImages.Add(image);
                RenderImageToPanel(image.ImageSrc, true);
            }

            specs.AddRange(product.ProductSpecifications);
            dgvSpecifications.DataSource = specs.Select(s => new
            {
                s.SpecName,
                s.SpecValue
            }).ToList();
        }

        private bool ProcessData()
        {
            string productId = txtProductId.Text;
            string productName = txtProductName.Text;
            string price = txtPrice.Text;
            string originalPrice = txtOriginalPrice.Text;
            string manuYear = txtManuYear.Text;
            string warranty = txtWarranty.Text;

            if(string.IsNullOrEmpty(productId))
            {
                MessageBox.Show("Mã sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (RegexUtils.ContainsSpecialCharacters(productId))
            {
                MessageBox.Show("Mã sản phẩm không được chứa ký tự đặc biệt và khoảng trắng, ngoại trừ -, _", 
                    "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Tên sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Giá sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrEmpty(originalPrice))
            {
                if (decimal.Parse(originalPrice) < decimal.Parse(price))
                {
                    MessageBox.Show("Giá so sánh phải lớn hơn giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if(decimal.Parse(price) < 0)
            {
                MessageBox.Show("Giá sản phẩm không được âm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            

            return true;
        }

        private async Task uploadImagesToAzure(string productId, string productName)
        {
            foreach(ProductImage image in images)
            {
                byte[] imageBytes = File.ReadAllBytes(image.ImageSrc);
                string extension = Path.GetExtension(image.ImageSrc);
                string path = $"products/{productId}/{FormatString.ToSlug(productName)}-{RandomUtils.GenerateRandomString(10)}{extension}";

                string src = await azureCloud.UploadImage(path, imageBytes);
                image.ImageSrc = src;
            }
        }

        private void AddUpdateProductForm_Load(object sender, EventArgs e)
        {
            initUI();
        }

        private void initUI()
        {
            List<Brand> brands = new List<Brand>
            {
                new Brand
                {
                    BrandId = null,
                    BrandName = "Chọn hãng sản xuất"
                }
            };
            brands.AddRange(brandBLL.GetBrands());

            List<Category> categories = new List<Category>
            {
                new Category
                {
                    CategoryId = null,
                    CategoryName = "Chọn danh mục"
                }
            };
            categories.AddRange(categoryBLL.GetCategories());

            cbbBrands.DataSource = brands;
            cbbBrands.ValueMember = nameof(Brand.BrandId);
            cbbBrands.DisplayMember = nameof(Brand.BrandName);

            cbbCategories.DataSource = categories;
            cbbCategories.ValueMember = nameof(Category.CategoryId);
            cbbCategories.DisplayMember = nameof(Category.CategoryName);

            btnUploadImages.BackColor = MyColors.LIGHTBLUE;
            btnAddSpec.BackColor = MyColors.LIGHTBLUE;
            btnSubmit.BackColor = MyColors.GREEN;

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "DeleteButton",
                HeaderText = "",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvSpecifications.Columns.Add(deleteButtonColumn);
            dgvSpecifications.CellContentClick += DgvSpecifications_CellContentClick;

            if (isUpdate)
            {
                txtProductId.Enabled = false;
                btnSubmit.Text = "Cập nhật";

                LoadProductFormData();
            }
        }

        private void DgvSpecifications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSpecifications.Columns[e.ColumnIndex].Name != "DeleteButton")
            {
                return;
            }

            var selectedRow = dgvSpecifications.Rows[e.RowIndex];

            var itemToDelete = specs
                .FirstOrDefault(s => s.SpecName == selectedRow.Cells["SpecName"].Value.ToString() 
                                && s.SpecValue == selectedRow.Cells["SpecValue"].Value.ToString());
            specs.Remove(itemToDelete);

            dgvSpecifications.DataSource = specs.Select(s => new
            {
                s.SpecName,
                s.SpecValue
            }).ToList();
        }
    }
}
