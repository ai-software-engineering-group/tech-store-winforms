﻿namespace PTPM_AI_CT3.Forms
{
    partial class BrandForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 15;
            this.dataGridView1.Size = new System.Drawing.Size(884, 500);
            this.dataGridView1.TabIndex = 1;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.buttonFind);
            this.panelButtons.Controls.Add(this.buttonInsert);
            this.panelButtons.Controls.Add(this.buttonDelete);
            this.panelButtons.Controls.Add(this.buttonUpdate);
            this.panelButtons.Controls.Add(this.buttonRefresh);
            this.panelButtons.Location = new System.Drawing.Point(12, 3);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(884, 50);
            this.panelButtons.TabIndex = 2;
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.buttonFind.ForeColor = System.Drawing.Color.White;
            this.buttonFind.Location = new System.Drawing.Point(453, 5);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(80, 30);
            this.buttonFind.TabIndex = 6;
            this.buttonFind.Text = "Tìm";
            this.buttonFind.UseVisualStyleBackColor = false;
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonInsert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.buttonInsert.ForeColor = System.Drawing.Color.White;
            this.buttonInsert.Location = new System.Drawing.Point(10, 5);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(80, 30);
            this.buttonInsert.TabIndex = 2;
            this.buttonInsert.Text = "Thêm";
            this.buttonInsert.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Crimson;
            this.buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(96, 5);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(80, 30);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Xóa ";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Location = new System.Drawing.Point(182, 5);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(80, 30);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Sửa";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Orange;
            this.buttonRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(354, 5);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(80, 30);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Làm mới";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(808, 16);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(389, 20);
            this.textBoxSearch.TabIndex = 7;
            // 
            // BrandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(909, 566);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BrandForm";
            this.Text = "Quản lý hãng sản xuất";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }




        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}
