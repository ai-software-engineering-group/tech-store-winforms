using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using BLL;
using DTO;
using UserControls;

namespace PTPM_AI_CT3.Forms
{
    public partial class BrandForm : Form
    {
        BrandBLL brandbll = new BrandBLL();

        public BrandForm()
        {
            InitializeComponent();
            this.Load += loadBrand;
            this.buttonInsert.Click += ButtonInsert_Click;
            this.buttonDelete.Click += ButtonDelete_Click;
            this.buttonUpdate.Click += ButtonUpdate_Click;
            this.buttonRefresh.Click += ButtonRefresh_Click;
            this.buttonFind.Click += ButtonFind_Click;

        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            string brandId = textBoxSearch.Text;  
            if (string.IsNullOrEmpty(brandId))
            {
                MessageBox.Show("Vui lòng nhập Mã Thương Hiệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Brand foundBrand = brandbll.find_brand(brandId);

            if (foundBrand != null)
            {
                dataGridView1.Rows.Clear();
                string imageUrl = foundBrand.LogoSrc;
                Bitmap brandImage = LoadImageFromUrl(imageUrl);
                dataGridView1.Rows.Add(foundBrand.BrandId, foundBrand.BrandName, brandImage);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thương hiệu với Mã đã cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void loadBrand(object sender, EventArgs e)
        {
            loadDB();
        }

        public void loadDB()
        {
            var brands = brandbll.GetBrands();

            if (dataGridView1.Columns["BrandId"] == null)
            {
                dataGridView1.Columns.Add("BrandId", "Mã Thương Hiệu");
            }

            if (dataGridView1.Columns["BrandName"] == null)
            {
                dataGridView1.Columns.Add("BrandName", "Tên Thương Hiệu");
            }

            if (dataGridView1.Columns["Logo"] == null)
            {
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.HeaderText = "Logo";
                imageColumn.Name = "Logo";
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridView1.Columns.Add(imageColumn);
            }

            dataGridView1.Rows.Clear();
            foreach (var brand in brands)
            {
                string imageUrl = brand.LogoSrc;
                Bitmap brandImage = LoadImageFromUrl(imageUrl);

                dataGridView1.Rows.Add(brand.BrandId, brand.BrandName, brandImage);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }






        private Bitmap LoadImageFromUrl(string imageUrl)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageData = webClient.DownloadData(imageUrl);
                    using (var memoryStream = new System.IO.MemoryStream(imageData))
                    {
                        return new Bitmap(memoryStream);
                    }
                }
            }
            catch (Exception ex)
            {
               
                return null; 
            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            loadDB();
        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            InsertBrand insertBrandControl = new InsertBrand();
            insertBrandControl.Dock = DockStyle.Fill;
            this.Controls.Add(insertBrandControl);
            insertBrandControl.BringToFront();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells["BrandId"].Value != null)
            {
                string selectedBrandId = dataGridView1.CurrentRow.Cells["BrandId"].Value.ToString();
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa thương hiệu này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (brandbll.xoaBrand(selectedBrandId))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDB();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thương hiệu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            updateBrand updateBrandControl = new updateBrand();
            updateBrandControl.Dock = DockStyle.Fill;
            this.Controls.Add(updateBrandControl);
            updateBrandControl.BringToFront();
        }
    }
}
