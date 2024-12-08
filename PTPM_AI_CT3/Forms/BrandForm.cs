using System;
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
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            loadDB();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            updateBrand updateBrandControl = new updateBrand();
            updateBrandControl.Dock = DockStyle.Fill;
            this.Controls.Add(updateBrandControl);
            updateBrandControl.BringToFront();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
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


        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            InsertBrand insertBrandControl = new InsertBrand();
            insertBrandControl.Dock = DockStyle.Fill;
            this.Controls.Add(insertBrandControl);
            insertBrandControl.BringToFront();
        }

       
        public void loadDB()
        {
            dataGridView1.DataSource = brandbll.GetBrands();
        }

        private void loadBrand(object sender, EventArgs e)
        {
            loadDB();
        }
    }
}
