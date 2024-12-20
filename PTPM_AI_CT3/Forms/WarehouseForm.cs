﻿using System;
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
using PTPM_AI_CT3.Constants;

namespace PTPM_AI_CT3
{
    public partial class WarehouseForm : Form
    {
        WarehouseBLL wareHouseBll = new WarehouseBLL();
        public WarehouseForm()
        {
            InitializeComponent();

            buttonAdd.BackColor = MyColors.GREEN;
            buttonDelete.BackColor = MyColors.RED;
            buttonEdit.BackColor = MyColors.LIGHTBLUE;

            this.Load += WarehouseForm_Load;
            this.buttonAdd.Click += ButtonThem_Click;
            this.buttonDelete.Click += ButtonXoa_Click;
            this.buttonEdit.Click += ButtonSua_Click;
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
                textWard.Text = selectedRow.Cells["Ward"].Value?.ToString();
                textDistrict.Text = selectedRow.Cells["District"].Value?.ToString();
                textProvince.Text = selectedRow.Cells["Province"].Value?.ToString();
            }
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            var warehouse = new warehouseDTO
            {
                WareHouseId = textWareHouseID.Text,
                WareHouseName = textWareHouseName.Text,
                Address = textAddress.Text,
                Ward = textWard.Text,
                District = textDistrict.Text,
                Province = textProvince.Text,
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
            if (string.IsNullOrWhiteSpace(textWareHouseID.Text) ||
                string.IsNullOrWhiteSpace(textWareHouseName.Text) ||
                string.IsNullOrWhiteSpace(textAddress.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            var warehouse = new Warehouse
            {
                WarehouseId = textWareHouseID.Text,
                WarehouseName = textWareHouseName.Text,
                Address = textAddress.Text,
                Ward = textWard.Text,
                WardCode = "",
                District = textDistrict.Text,
                DistrictCode = "",
                Province = textProvince.Text,
                ProvinceCode ="" ,
         
            };

            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            this.dataGridView1.DataSource = wareHouseBll.GetWareHouse();

            dataGridView1.Columns[nameof(Warehouse.WarehouseId)].HeaderText = "Mã kho";
            dataGridView1.Columns[nameof(Warehouse.WarehouseName)].HeaderText = "Tên kho";
            dataGridView1.Columns[nameof(Warehouse.Address)].HeaderText = "Địa chỉ";
            dataGridView1.Columns[nameof(Warehouse.Ward)].HeaderText = "Xã/phường";
            dataGridView1.Columns[nameof(Warehouse.District)].HeaderText = "Quận/huyện";
            dataGridView1.Columns[nameof(Warehouse.Province)].HeaderText = "Tỉnh/TP";

            dataGridView1.Columns[nameof(Warehouse.Type)].Visible = false;
        }
    }
}
