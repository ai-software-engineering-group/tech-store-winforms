namespace UserControls
{
    partial class ProductListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteProduct = new FontAwesome.Sharp.IconButton();
            this.btnEditProduct = new FontAwesome.Sharp.IconButton();
            this.lblInstock = new System.Windows.Forms.Label();
            this.productImage = new System.Windows.Forms.PictureBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblOriginalPrice = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblInstock, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.productImage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPrice, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOriginalPrice, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblProductName, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(767, 37);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeleteProduct);
            this.panel1.Controls.Add(this.btnEditProduct);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(657, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 33);
            this.panel1.TabIndex = 23;
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnDeleteProduct.IconColor = System.Drawing.Color.Black;
            this.btnDeleteProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDeleteProduct.IconSize = 20;
            this.btnDeleteProduct.Location = new System.Drawing.Point(76, 0);
            this.btnDeleteProduct.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(30, 32);
            this.btnDeleteProduct.TabIndex = 8;
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.ForeColor = System.Drawing.Color.White;
            this.btnEditProduct.IconChar = FontAwesome.Sharp.IconChar.PenAlt;
            this.btnEditProduct.IconColor = System.Drawing.Color.Black;
            this.btnEditProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditProduct.IconSize = 20;
            this.btnEditProduct.Location = new System.Drawing.Point(42, 0);
            this.btnEditProduct.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(30, 32);
            this.btnEditProduct.TabIndex = 7;
            this.btnEditProduct.UseVisualStyleBackColor = true;
            // 
            // lblInstock
            // 
            this.lblInstock.AutoSize = true;
            this.lblInstock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInstock.Location = new System.Drawing.Point(587, 0);
            this.lblInstock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInstock.Name = "lblInstock";
            this.lblInstock.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblInstock.Size = new System.Drawing.Size(66, 37);
            this.lblInstock.TabIndex = 20;
            this.lblInstock.Text = "2";
            this.lblInstock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // productImage
            // 
            this.productImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productImage.Location = new System.Drawing.Point(42, 2);
            this.productImage.Margin = new System.Windows.Forms.Padding(2);
            this.productImage.Name = "productImage";
            this.productImage.Size = new System.Drawing.Size(41, 33);
            this.productImage.TabIndex = 16;
            this.productImage.TabStop = false;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrice.Location = new System.Drawing.Point(486, 0);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblPrice.Size = new System.Drawing.Size(97, 37);
            this.lblPrice.TabIndex = 19;
            this.lblPrice.Text = "990.000đ";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOriginalPrice
            // 
            this.lblOriginalPrice.AutoSize = true;
            this.lblOriginalPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOriginalPrice.Location = new System.Drawing.Point(371, 0);
            this.lblOriginalPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOriginalPrice.Name = "lblOriginalPrice";
            this.lblOriginalPrice.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblOriginalPrice.Size = new System.Drawing.Size(111, 37);
            this.lblOriginalPrice.TabIndex = 18;
            this.lblOriginalPrice.Text = "1.000.000đ";
            this.lblOriginalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNo.Location = new System.Drawing.Point(2, 0);
            this.lblNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(36, 37);
            this.lblNo.TabIndex = 22;
            this.lblNo.Text = "1";
            this.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(87, 0);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblProductName.Size = new System.Drawing.Size(280, 37);
            this.lblProductName.TabIndex = 17;
            this.lblProductName.Text = "Product name";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProductListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductListItem";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(779, 49);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblInstock;
        private System.Windows.Forms.PictureBox productImage;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblOriginalPrice;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnDeleteProduct;
        private FontAwesome.Sharp.IconButton btnEditProduct;
    }
}
