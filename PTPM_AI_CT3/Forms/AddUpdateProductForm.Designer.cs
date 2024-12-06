namespace PTPM_AI_CT3.Forms
{
    partial class AddUpdateProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSubmit = new FontAwesome.Sharp.IconButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSpecName = new System.Windows.Forms.TextBox();
            this.txtSpecValue = new System.Windows.Forms.TextBox();
            this.btnAddSpec = new FontAwesome.Sharp.IconButton();
            this.dgvSpecifications = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtShortDescription = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelImages = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnUploadImages = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbBrands = new System.Windows.Forms.ComboBox();
            this.cbbCategories = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtPrice = new UserControls.TxtPositiveNumber();
            this.txtOriginalPrice = new UserControls.TxtPositiveNumber();
            this.txtManuYear = new UserControls.TxtPositiveNumber();
            this.txtWarranty = new UserControls.TxtPositiveNumber();
            this.SpecName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecifications)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 38);
            this.panel1.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Silver;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnSubmit.IconColor = System.Drawing.Color.White;
            this.btnSubmit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSubmit.IconSize = 17;
            this.btnSubmit.Location = new System.Drawing.Point(3, 0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(102, 32);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Thêm mới";
            this.btnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(12, 848);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.panel6.Size = new System.Drawing.Size(831, 207);
            this.panel6.TabIndex = 9;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.tableLayoutPanel3);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(831, 192);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Thông số kỹ thuật";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.16865F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.83135F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dgvSpecifications, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(825, 173);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtSpecName, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtSpecValue, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnAddSpec, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(399, 101);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Location = new System.Drawing.Point(3, 8);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Tên thông số";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Location = new System.Drawing.Point(3, 40);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Mô tả thông số";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSpecName
            // 
            this.txtSpecName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSpecName.Location = new System.Drawing.Point(123, 8);
            this.txtSpecName.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtSpecName.Name = "txtSpecName";
            this.txtSpecName.Size = new System.Drawing.Size(273, 20);
            this.txtSpecName.TabIndex = 9;
            // 
            // txtSpecValue
            // 
            this.txtSpecValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSpecValue.Location = new System.Drawing.Point(123, 40);
            this.txtSpecValue.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtSpecValue.Name = "txtSpecValue";
            this.txtSpecValue.Size = new System.Drawing.Size(273, 20);
            this.txtSpecValue.TabIndex = 11;
            // 
            // btnAddSpec
            // 
            this.btnAddSpec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddSpec.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddSpec.ForeColor = System.Drawing.Color.White;
            this.btnAddSpec.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddSpec.IconColor = System.Drawing.Color.White;
            this.btnAddSpec.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddSpec.IconSize = 17;
            this.btnAddSpec.Location = new System.Drawing.Point(330, 67);
            this.btnAddSpec.Name = "btnAddSpec";
            this.btnAddSpec.Size = new System.Drawing.Size(66, 31);
            this.btnAddSpec.TabIndex = 12;
            this.btnAddSpec.Text = "Thêm";
            this.btnAddSpec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddSpec.UseVisualStyleBackColor = false;
            // 
            // dgvSpecifications
            // 
            this.dgvSpecifications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSpecifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpecifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SpecName,
            this.SpecValue});
            this.dgvSpecifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpecifications.Location = new System.Drawing.Point(408, 3);
            this.dgvSpecifications.Name = "dgvSpecifications";
            this.dgvSpecifications.Size = new System.Drawing.Size(414, 167);
            this.dgvSpecifications.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(12, 701);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.panel5.Size = new System.Drawing.Size(831, 147);
            this.panel5.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.txtDescription);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(831, 132);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mô tả sản phẩm (HTML)";
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(3, 16);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(825, 113);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.Text = "";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(12, 554);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.panel4.Size = new System.Drawing.Size(831, 147);
            this.panel4.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.txtShortDescription);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(831, 132);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mô tả ngắn (HTML)";
            // 
            // txtShortDescription
            // 
            this.txtShortDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShortDescription.Location = new System.Drawing.Point(3, 16);
            this.txtShortDescription.Name = "txtShortDescription";
            this.txtShortDescription.Size = new System.Drawing.Size(825, 113);
            this.txtShortDescription.TabIndex = 0;
            this.txtShortDescription.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(12, 251);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.panel2.Size = new System.Drawing.Size(831, 303);
            this.panel2.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.panelImages);
            this.groupBox2.Controls.Add(this.panel7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(831, 288);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hình ảnh";
            // 
            // panelImages
            // 
            this.panelImages.AutoScroll = true;
            this.panelImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImages.Location = new System.Drawing.Point(3, 60);
            this.panelImages.Name = "panelImages";
            this.panelImages.Size = new System.Drawing.Size(825, 225);
            this.panelImages.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnUploadImages);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 16);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(825, 44);
            this.panel7.TabIndex = 0;
            // 
            // btnUploadImages
            // 
            this.btnUploadImages.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUploadImages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadImages.ForeColor = System.Drawing.Color.White;
            this.btnUploadImages.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnUploadImages.IconColor = System.Drawing.Color.White;
            this.btnUploadImages.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUploadImages.IconSize = 18;
            this.btnUploadImages.Location = new System.Drawing.Point(11, 8);
            this.btnUploadImages.Name = "btnUploadImages";
            this.btnUploadImages.Size = new System.Drawing.Size(138, 29);
            this.btnUploadImages.TabIndex = 0;
            this.btnUploadImages.Text = "Chọn hình ảnh";
            this.btnUploadImages.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUploadImages.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 12, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(831, 201);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbbBrands, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbbCategories, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtPrice, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtOriginalPrice, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtManuYear, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtWarranty, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 89);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(815, 100);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hãng sản xuất";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Giá bán";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(3, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Năm sản xuất";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(400, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Giá so sánh";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(400, 40);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Thời gian bảo hành";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(400, 72);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Doanh mục";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbBrands
            // 
            this.cbbBrands.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbBrands.FormattingEnabled = true;
            this.cbbBrands.Location = new System.Drawing.Point(103, 72);
            this.cbbBrands.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cbbBrands.Name = "cbbBrands";
            this.cbbBrands.Size = new System.Drawing.Size(291, 23);
            this.cbbBrands.TabIndex = 13;
            // 
            // cbbCategories
            // 
            this.cbbCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbCategories.FormattingEnabled = true;
            this.cbbCategories.Location = new System.Drawing.Point(520, 72);
            this.cbbCategories.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cbbCategories.Name = "cbbCategories";
            this.cbbCategories.Size = new System.Drawing.Size(292, 23);
            this.cbbCategories.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtProductName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtProductId, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(815, 63);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên sản phẩm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProductName
            // 
            this.txtProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductName.Location = new System.Drawing.Point(103, 38);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(709, 21);
            this.txtProductName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sản phẩm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProductId
            // 
            this.txtProductId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductId.Location = new System.Drawing.Point(103, 8);
            this.txtProductId.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(709, 21);
            this.txtProductId.TabIndex = 1;
            // 
            // txtPrice
            // 
            this.txtPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPrice.Location = new System.Drawing.Point(103, 8);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(291, 21);
            this.txtPrice.TabIndex = 15;
            // 
            // txtOriginalPrice
            // 
            this.txtOriginalPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtOriginalPrice.Location = new System.Drawing.Point(520, 8);
            this.txtOriginalPrice.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtOriginalPrice.Name = "txtOriginalPrice";
            this.txtOriginalPrice.Size = new System.Drawing.Size(292, 21);
            this.txtOriginalPrice.TabIndex = 16;
            // 
            // txtManuYear
            // 
            this.txtManuYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtManuYear.Location = new System.Drawing.Point(103, 40);
            this.txtManuYear.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtManuYear.Name = "txtManuYear";
            this.txtManuYear.Size = new System.Drawing.Size(291, 21);
            this.txtManuYear.TabIndex = 17;
            // 
            // txtWarranty
            // 
            this.txtWarranty.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtWarranty.Location = new System.Drawing.Point(520, 40);
            this.txtWarranty.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtWarranty.Name = "txtWarranty";
            this.txtWarranty.Size = new System.Drawing.Size(292, 21);
            this.txtWarranty.TabIndex = 18;
            // 
            // SpecName
            // 
            this.SpecName.DataPropertyName = "SpecName";
            this.SpecName.HeaderText = "Tên thông số";
            this.SpecName.Name = "SpecName";
            // 
            // SpecValue
            // 
            this.SpecValue.DataPropertyName = "SpecValue";
            this.SpecValue.HeaderText = "Mô tả thông số";
            this.SpecValue.Name = "SpecValue";
            // 
            // AddUpdateProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(872, 774);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "AddUpdateProductForm";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Thêm sản phẩm";
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecifications)).EndInit();
            this.panel5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSpecName;
        private System.Windows.Forms.TextBox txtSpecValue;
        private FontAwesome.Sharp.IconButton btnAddSpec;
        private System.Windows.Forms.DataGridView dgvSpecifications;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txtShortDescription;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panelImages;
        private System.Windows.Forms.Panel panel7;
        private FontAwesome.Sharp.IconButton btnUploadImages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbBrands;
        private System.Windows.Forms.ComboBox cbbCategories;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductId;
        private FontAwesome.Sharp.IconButton btnSubmit;
        private UserControls.TxtPositiveNumber txtPrice;
        private UserControls.TxtPositiveNumber txtOriginalPrice;
        private UserControls.TxtPositiveNumber txtManuYear;
        private UserControls.TxtPositiveNumber txtWarranty;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecValue;
    }
}