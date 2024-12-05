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

namespace PTPM_AI_CT3.Forms
{
    public partial class AddUpdateProductForm : Form
    {
        private CategoryBLL categoryBLL;
        private BrandBLL brandBLL;
        private ProductBLL productBLL;

        public bool isUpdate;
        public string productUpdateId;

        public AddUpdateProductForm(bool isUpdate, string productUpdateId)
        {
            InitializeComponent();

            this.isUpdate = isUpdate;
            this.productUpdateId = productUpdateId;

            categoryBLL = new CategoryBLL();
            brandBLL = new BrandBLL();
            productBLL = new ProductBLL();

            this.Load += AddUpdateProductForm_Load;
        }

        private void AddUpdateProductForm_Load(object sender, EventArgs e)
        {
            initUI();
        }

        private void initUI()
        {
            btnUploadImages.BackColor = MyColors.LIGHTBLUE;
            btnAddSpec.BackColor = MyColors.LIGHTBLUE;

            if(isUpdate)
            {
                txtProductId.Enabled = false;

               // Product product = productBLL.GetProductById(productUpdateId);
            }

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
        }
    }
}
