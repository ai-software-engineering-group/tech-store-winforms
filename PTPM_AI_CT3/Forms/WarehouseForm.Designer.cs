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
            this.panelForm = new System.Windows.Forms.Panel();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.textProvince = new System.Windows.Forms.TextBox();
            this.textDistrict = new System.Windows.Forms.TextBox();
            this.textWard = new System.Windows.Forms.TextBox();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.textWareHouseName = new System.Windows.Forms.TextBox();
            this.textWareHouseID = new System.Windows.Forms.TextBox();
            this.labelDistrict = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelProvince = new System.Windows.Forms.Label();
            this.labelWard = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelWarehouseName = new System.Windows.Forms.Label();
            this.labelWarehouseID = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForm.Controls.Add(this.buttonEdit);
            this.panelForm.Controls.Add(this.buttonDelete);
            this.panelForm.Controls.Add(this.buttonAdd);
            this.panelForm.Controls.Add(this.cbType);
            this.panelForm.Controls.Add(this.textProvince);
            this.panelForm.Controls.Add(this.textDistrict);
            this.panelForm.Controls.Add(this.textWard);
            this.panelForm.Controls.Add(this.textAddress);
            this.panelForm.Controls.Add(this.textWareHouseName);
            this.panelForm.Controls.Add(this.textWareHouseID);
            this.panelForm.Controls.Add(this.labelDistrict);
            this.panelForm.Controls.Add(this.labelType);
            this.panelForm.Controls.Add(this.labelProvince);
            this.panelForm.Controls.Add(this.labelWard);
            this.panelForm.Controls.Add(this.labelAddress);
            this.panelForm.Controls.Add(this.labelWarehouseName);
            this.panelForm.Controls.Add(this.labelWarehouseID);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 60);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(800, 250);
            this.panelForm.TabIndex = 1;
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.Location = new System.Drawing.Point(240, 185);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(90, 35);
            this.buttonEdit.TabIndex = 19;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Red;
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(130, 185);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(90, 35);
            this.buttonDelete.TabIndex = 18;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(11, 185);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(90, 35);
            this.buttonAdd.TabIndex = 17;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(460, 100);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(200, 21);
            this.cbType.TabIndex = 20;
            // 
            // textProvince
            // 
            this.textProvince.Location = new System.Drawing.Point(460, 60);
            this.textProvince.Name = "textProvince";
            this.textProvince.Size = new System.Drawing.Size(200, 20);
            this.textProvince.TabIndex = 16;
            // 
            // textDistrict
            // 
            this.textDistrict.Location = new System.Drawing.Point(130, 140);
            this.textDistrict.Name = "textDistrict";
            this.textDistrict.Size = new System.Drawing.Size(200, 20);
            this.textDistrict.TabIndex = 15;
            // 
            // textWard
            // 
            this.textWard.Location = new System.Drawing.Point(460, 20);
            this.textWard.Name = "textWard";
            this.textWard.Size = new System.Drawing.Size(200, 20);
            this.textWard.TabIndex = 14;
            // 
            // textAddress
            // 
            this.textAddress.Location = new System.Drawing.Point(130, 100);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(200, 20);
            this.textAddress.TabIndex = 13;
            // 
            // textWareHouseName
            // 
            this.textWareHouseName.Location = new System.Drawing.Point(130, 60);
            this.textWareHouseName.Name = "textWareHouseName";
            this.textWareHouseName.Size = new System.Drawing.Size(200, 20);
            this.textWareHouseName.TabIndex = 12;
            // 
            // textWareHouseID
            // 
            this.textWareHouseID.Location = new System.Drawing.Point(130, 20);
            this.textWareHouseID.Name = "textWareHouseID";
            this.textWareHouseID.Size = new System.Drawing.Size(200, 20);
            this.textWareHouseID.TabIndex = 11;
            // 
            // labelDistrict
            // 
            this.labelDistrict.AutoSize = true;
            this.labelDistrict.Location = new System.Drawing.Point(10, 140);
            this.labelDistrict.Name = "labelDistrict";
            this.labelDistrict.Size = new System.Drawing.Size(42, 13);
            this.labelDistrict.TabIndex = 10;
            this.labelDistrict.Text = "District:";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(380, 100);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(34, 13);
            this.labelType.TabIndex = 9;
            this.labelType.Text = "Type:";
            // 
            // labelProvince
            // 
            this.labelProvince.AutoSize = true;
            this.labelProvince.Location = new System.Drawing.Point(380, 60);
            this.labelProvince.Name = "labelProvince";
            this.labelProvince.Size = new System.Drawing.Size(52, 13);
            this.labelProvince.TabIndex = 8;
            this.labelProvince.Text = "Province:";
            // 
            // labelWard
            // 
            this.labelWard.AutoSize = true;
            this.labelWard.Location = new System.Drawing.Point(380, 20);
            this.labelWard.Name = "labelWard";
            this.labelWard.Size = new System.Drawing.Size(36, 13);
            this.labelWard.TabIndex = 7;
            this.labelWard.Text = "Ward:";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(10, 100);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(48, 13);
            this.labelAddress.TabIndex = 6;
            this.labelAddress.Text = "Address:";
            // 
            // labelWarehouseName
            // 
            this.labelWarehouseName.AutoSize = true;
            this.labelWarehouseName.Location = new System.Drawing.Point(10, 60);
            this.labelWarehouseName.Name = "labelWarehouseName";
            this.labelWarehouseName.Size = new System.Drawing.Size(96, 13);
            this.labelWarehouseName.TabIndex = 5;
            this.labelWarehouseName.Text = "Warehouse Name:";
            // 
            // labelWarehouseID
            // 
            this.labelWarehouseID.AutoSize = true;
            this.labelWarehouseID.Location = new System.Drawing.Point(10, 20);
            this.labelWarehouseID.Name = "labelWarehouseID";
            this.labelWarehouseID.Size = new System.Drawing.Size(79, 13);
            this.labelWarehouseID.TabIndex = 4;
            this.labelWarehouseID.Text = "Warehouse ID:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 310);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 290);
            this.dataGridView1.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(20, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(257, 45);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Warehouse Info";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 60);
            this.panelHeader.TabIndex = 2;
            // 
            // WarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelHeader);
            this.Name = "WarehouseForm";
            this.Text = "Warehouse Management";
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Label labelWarehouseID;
        private System.Windows.Forms.Label labelWarehouseName;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelWard;
        private System.Windows.Forms.Label labelProvince;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelDistrict;
        private System.Windows.Forms.TextBox textWareHouseID;
        private System.Windows.Forms.TextBox textWareHouseName;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.TextBox textWard;
        private System.Windows.Forms.TextBox textDistrict;
        private System.Windows.Forms.TextBox textProvince;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.DataGridView dataGridView1;

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelHeader;
    }
}
