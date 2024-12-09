using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using DAL;
namespace PTPM_AI_CT3.Forms
{
    public partial class CategoryForm : Form
    {
        CategoryBLL categoryBLL = new CategoryBLL();
        private CategoryDAL categoryDAL;
        public CategoryForm()
        {
            InitializeComponent();
            categoryDAL = new CategoryDAL();
            dgv_DM.CellClick += Dgv_DM_CellClick;
            this.Load += CategoryForm_Load;
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
        }
        private void LoadDanhMuc()
        {
            var categories = categoryBLL.GetCategory();
            if (categories != null && categories.Any())
            {
                dgv_DM.DataSource = categories;
                dgv_DM.Columns["CategoryId"].HeaderText = "Mã danh mục";
                dgv_DM.Columns["CategoryName"].HeaderText = "Tên danh mục";
                dgv_DM.Columns["ImageSrc"].HeaderText = "Hình ảnh";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!");
            }
        }


        private void Dgv_DM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_DM.Rows[e.RowIndex];
                txt_MaDM.Text = row.Cells["CategoryId"].Value?.ToString();
                txt_TenDM.Text = row.Cells["CategoryName"].Value?.ToString();
                txt_URL.Text = row.Cells["ImageSrc"].Value?.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thêm danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var category = new Category
                {
                    CategoryId = txt_MaDM.Text,
                    CategoryName = txt_TenDM.Text,
                    ImageSrc = txt_URL.Text
                };

                if (categoryBLL.AddCategory(category))
                {
                    MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhMuc();
                }
                else
                {
                    MessageBox.Show("Thêm danh mục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var categoryId = txt_MaDM.Text;
                if (categoryBLL.DeleteCategory(categoryId))
                {
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhMuc();
                }
                else
                {
                    MessageBox.Show("Xóa danh mục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn sửa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var category = new Category
                {
                    CategoryId = txt_MaDM.Text,
                    CategoryName = txt_TenDM.Text,
                    ImageSrc = txt_URL.Text
                };

                if (categoryBLL.UpdateCategory(category))
                {
                    MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhMuc();
                }
                else
                {
                    MessageBox.Show("Cập nhật danh mục thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
