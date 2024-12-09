using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using PTPM_AI_CT3.Auth;
using UserControls;

namespace PTPM_AI_CT3
{
    public partial class WareHouseExportForm : Form
    {
        WareHouseExportBLL warehouseExportBLL = new WareHouseExportBLL();

        public WareHouseExportForm()
        {
            InitializeComponent();
            this.Load += WareHouseExportForm_Load;
            this.buttonExport.Click += btnUpdate_Click;
            this.buttonSearch.Click += ButtonSearch_Click;
            dataGridView1.CellClick += DataGridView1_CellClick; 

        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            var weId = textBox1.Text.Trim(); 

            if (string.IsNullOrEmpty(weId))
            {
                loadData();
            }
            else
            {
                var result = warehouseExportBLL.SearchWarehouseExportById(weId);

                if (result != null)
                {
                    var resultList = new List<warehouseExportDTO> { result }; 
                    dataGridView1.DataSource = resultList; 
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu với ID xuất kho: " + weId);
                }
            }
        }


        private void WareHouseExportForm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            dataGridView1.DataSource = warehouseExportBLL.GetWarehouseExports();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var weId = textBox1.Text.Trim(); 
            var dateExport = DateTime.Now; 
            var note = textBox2.Text.Trim(); 

            var employeeId = AuthenticatedUser.Employee?.EmployeeId;

            if (string.IsNullOrEmpty(weId))
            {
                MessageBox.Show("Vui lòng nhập ID xuất kho!");
                return;
            }

            if (string.IsNullOrEmpty(employeeId))
            {
                MessageBox.Show("Không thể xác định nhân viên đang đăng nhập!");
                return;
            }

            var warehouseExport = new warehouseExportDTO
            {
                WEId = weId,
                DateExport = dateExport,
                EmployeeId = employeeId,
                Note = note
            };

            bool result = warehouseExportBLL.UpdateWarehouseExport(warehouseExport);

            if (result)
            {
                MessageBox.Show("Cập nhật thành công!");
                loadData(); 
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];

                if (dataGridView1.Columns[e.ColumnIndex].Name == "WEId")
                {
                    textBox1.Text = selectedRow.Cells["WEId"].Value?.ToString() ?? string.Empty;
                
                
                    var noteValue = selectedRow.Cells["Note"].Value;

                    if (noteValue == DBNull.Value || noteValue == null)
                    {
                        textBox2.Text = string.Empty; 
                    }
                    else
                    {
                        textBox2.Text = noteValue.ToString().Trim(); 
                    }
                }
            }
        }


    }
}
