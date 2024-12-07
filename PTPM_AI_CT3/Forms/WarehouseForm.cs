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

namespace PTPM_AI_CT3
{
    public partial class WarehouseForm : Form
    {
        WarehouseBLL wareHouseBll = new WarehouseBLL();
        public WarehouseForm()
        {
            InitializeComponent();
            this.Load += WarehouseForm_Load;
            this.buttonThem.Click += ButtonThem_Click;
            this.buttonXoa.Click += ButtonXoa_Click;
            this.buttonSua.Click += ButtonSua_Click;
            this.dataGridView1.CellClick += DataGridView1_Click;
        }

        private void DataGridView1_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                textWareHouseID.Text = selectedRow.Cells["WarehouseId"].Value?.ToString();
                textWareHouseName.Text = selectedRow.Cells["WarehouseName"].Value?.ToString();
                textAddress.Text = selectedRow.Cells["Address"].Value?.ToString();
                textWare.Text = selectedRow.Cells["Ward"].Value?.ToString();
                textWareCode.Text = selectedRow.Cells["WardCode"].Value?.ToString();
                textDistrict.Text = selectedRow.Cells["District"].Value?.ToString();
                textDistrictCode.Text = selectedRow.Cells["DistrictCode"].Value?.ToString();
                textProvince.Text = selectedRow.Cells["Province"].Value?.ToString();
                textProvinceCode.Text = selectedRow.Cells["ProvinceCode"].Value?.ToString();
                cbType.SelectedItem = selectedRow.Cells["Type"].Value?.ToString();
                textLatitude.Text = selectedRow.Cells["Latitude"].Value?.ToString();
                textLongtiture.Text = selectedRow.Cells["Longtitude"].Value?.ToString();
            }
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            var warehouse = new Warehouse
            {
                WarehouseId = textWareHouseID.Text,
                WarehouseName = textWareHouseName.Text,
                Address = textAddress.Text,
                Ward = textWare.Text,
                WardCode = textWareCode.Text,
                District = textDistrict.Text,
                DistrictCode = textDistrictCode.Text,
                Province = textProvince.Text,
                ProvinceCode = textProvinceCode.Text,
                Type = cbType.SelectedItem?.ToString(),
                Latitude = decimal.Parse(textLatitude.Text),
                Longtitude = decimal.Parse(textLongtiture.Text)
            };
            if (wareHouseBll.updaate_warehouse(warehouse))
            {
                MessageBox.Show("Warehouse update successfully!");
                loadData();
            }
            else
            {
                MessageBox.Show("Failed to upadte warehouse.");
            }

        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            var warehouse = new Warehouse();
            string warehouse_id = warehouse.WarehouseId;
            warehouse_id = textWareHouseID.Text;
            if (wareHouseBll.delete_wareHouse(warehouse_id))
            {
                MessageBox.Show("Warehouse remove successfully!");
                loadData();
            }
            else
            {
                MessageBox.Show("Don't have anything to remove");
            }


        }

        private void ButtonThem_Click(object sender, EventArgs e)
        {
            var warehouse = new Warehouse
            {
                WarehouseId = textWareHouseID.Text,
                WarehouseName = textWareHouseName.Text,
                Address = textAddress.Text,
                Ward = textWare.Text,
                WardCode = textWareCode.Text,
                District = textDistrict.Text,
                DistrictCode = textDistrictCode.Text,
                Province = textProvince.Text,
                ProvinceCode = textProvinceCode.Text,
                Type = cbType.SelectedItem?.ToString(),
                Latitude = decimal.Parse(textLatitude.Text),
                Longtitude = decimal.Parse(textLongtiture.Text)
            };

            if (wareHouseBll.insertWareHouse(warehouse))
            {
                MessageBox.Show("Warehouse added successfully!");
                loadData();
            }
            else
            {
                MessageBox.Show("Failed to add warehouse.");
            }
        }


        private void combobox_item()
        {
            cbType.Items.Clear();
            cbType.Items.Add("");
            cbType.Items.Add("online");
            if (cbType.Items.Count > 0)
            {
                cbType.SelectedIndex = 0;
            }
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            this.dataGridView1.DataSource = wareHouseBll.GetWareHouse();
            combobox_item();
        }
    }
}
