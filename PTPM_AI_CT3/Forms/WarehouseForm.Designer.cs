namespace PTPM_AI_CT3
{
    partial class WarehouseForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textProvince = new System.Windows.Forms.TextBox();
            this.textDistrict = new System.Windows.Forms.TextBox();
            this.textWard = new System.Windows.Forms.TextBox();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.textWareHouseName = new System.Windows.Forms.TextBox();
            this.textWareHouseID = new System.Windows.Forms.TextBox();
            this.labelDistrict = new System.Windows.Forms.Label();
            this.labelProvince = new System.Windows.Forms.Label();
            this.labelWard = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelWarehouseName = new System.Windows.Forms.Label();
            this.labelWarehouseID = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonEdit);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.textProvince);
            this.groupBox1.Controls.Add(this.textDistrict);
            this.groupBox1.Controls.Add(this.textWard);
            this.groupBox1.Controls.Add(this.textAddress);
            this.groupBox1.Controls.Add(this.textWareHouseName);
            this.groupBox1.Controls.Add(this.textWareHouseID);
            this.groupBox1.Controls.Add(this.labelDistrict);
            this.groupBox1.Controls.Add(this.labelProvince);
            this.groupBox1.Controls.Add(this.labelWard);
            this.groupBox1.Controls.Add(this.labelAddress);
            this.groupBox1.Controls.Add(this.labelWarehouseName);
            this.groupBox1.Controls.Add(this.labelWarehouseID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 203);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin kho";
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.Location = new System.Drawing.Point(106, 157);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(80, 30);
            this.buttonEdit.TabIndex = 34;
            this.buttonEdit.Text = "Sửa";
            this.buttonEdit.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Red;
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(202, 157);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(80, 30);
            this.buttonDelete.TabIndex = 33;
            this.buttonDelete.Text = "Xóa";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(10, 157);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(80, 30);
            this.buttonAdd.TabIndex = 32;
            this.buttonAdd.Text = "Thêm";
            this.buttonAdd.UseVisualStyleBackColor = false;
            // 
            // textProvince
            // 
            this.textProvince.Location = new System.Drawing.Point(484, 91);
            this.textProvince.Name = "textProvince";
            this.textProvince.Size = new System.Drawing.Size(200, 20);
            this.textProvince.TabIndex = 31;
            // 
            // textDistrict
            // 
            this.textDistrict.Location = new System.Drawing.Point(130, 94);
            this.textDistrict.Name = "textDistrict";
            this.textDistrict.Size = new System.Drawing.Size(200, 20);
            this.textDistrict.TabIndex = 30;
            // 
            // textWard
            // 
            this.textWard.Location = new System.Drawing.Point(484, 51);
            this.textWard.Name = "textWard";
            this.textWard.Size = new System.Drawing.Size(200, 20);
            this.textWard.TabIndex = 29;
            // 
            // textAddress
            // 
            this.textAddress.Location = new System.Drawing.Point(130, 54);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(200, 20);
            this.textAddress.TabIndex = 28;
            // 
            // textWareHouseName
            // 
            this.textWareHouseName.Location = new System.Drawing.Point(484, 19);
            this.textWareHouseName.Name = "textWareHouseName";
            this.textWareHouseName.Size = new System.Drawing.Size(200, 20);
            this.textWareHouseName.TabIndex = 27;
            // 
            // textWareHouseID
            // 
            this.textWareHouseID.Location = new System.Drawing.Point(130, 19);
            this.textWareHouseID.Name = "textWareHouseID";
            this.textWareHouseID.Size = new System.Drawing.Size(200, 20);
            this.textWareHouseID.TabIndex = 26;
            // 
            // labelDistrict
            // 
            this.labelDistrict.AutoSize = true;
            this.labelDistrict.Location = new System.Drawing.Point(19, 94);
            this.labelDistrict.Name = "labelDistrict";
            this.labelDistrict.Size = new System.Drawing.Size(67, 13);
            this.labelDistrict.TabIndex = 25;
            this.labelDistrict.Text = "Quận/huyện";
            // 
            // labelProvince
            // 
            this.labelProvince.AutoSize = true;
            this.labelProvince.Location = new System.Drawing.Point(375, 94);
            this.labelProvince.Name = "labelProvince";
            this.labelProvince.Size = new System.Drawing.Size(81, 13);
            this.labelProvince.TabIndex = 24;
            this.labelProvince.Text = "Tỉnh/thành phố";
            // 
            // labelWard
            // 
            this.labelWard.AutoSize = true;
            this.labelWard.Location = new System.Drawing.Point(395, 51);
            this.labelWard.Name = "labelWard";
            this.labelWard.Size = new System.Drawing.Size(61, 13);
            this.labelWard.TabIndex = 23;
            this.labelWard.Text = "Xã/phường";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(13, 58);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(73, 13);
            this.labelAddress.TabIndex = 22;
            this.labelAddress.Text = "Địa chỉ cụ thể";
            // 
            // labelWarehouseName
            // 
            this.labelWarehouseName.AutoSize = true;
            this.labelWarehouseName.Location = new System.Drawing.Point(409, 22);
            this.labelWarehouseName.Name = "labelWarehouseName";
            this.labelWarehouseName.Size = new System.Drawing.Size(47, 13);
            this.labelWarehouseName.TabIndex = 21;
            this.labelWarehouseName.Text = "Tên kho";
            // 
            // labelWarehouseID
            // 
            this.labelWarehouseID.AutoSize = true;
            this.labelWarehouseID.Location = new System.Drawing.Point(43, 26);
            this.labelWarehouseID.Name = "labelWarehouseID";
            this.labelWarehouseID.Size = new System.Drawing.Size(43, 13);
            this.labelWarehouseID.TabIndex = 20;
            this.labelWarehouseID.Text = "Mã kho";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(7, 210);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(786, 383);
            this.dataGridView1.TabIndex = 5;
            // 
            // WarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "WarehouseForm";

            this.Padding = new System.Windows.Forms.Padding(7);
            this.Text = "Kho hàng";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textProvince;
        private System.Windows.Forms.TextBox textDistrict;
        private System.Windows.Forms.TextBox textWard;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.TextBox textWareHouseName;
        private System.Windows.Forms.TextBox textWareHouseID;
        private System.Windows.Forms.Label labelDistrict;
        private System.Windows.Forms.Label labelProvince;
        private System.Windows.Forms.Label labelWard;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelWarehouseName;
        private System.Windows.Forms.Label labelWarehouseID;
        private System.Windows.Forms.DataGridView dataGridView1;
        #endregion
    }
}
