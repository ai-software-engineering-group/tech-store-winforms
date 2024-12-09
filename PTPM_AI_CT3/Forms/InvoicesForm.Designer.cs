using System.Drawing;
using System.Windows.Forms;

namespace PTPM_AI_CT3.Forms
{
    partial class InvoicesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonfind;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Panel panelTopSpacing;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Panel panelDataGrid1;
        private System.Windows.Forms.Panel panelSpacing;
        private System.Windows.Forms.Panel panelDataGrid2;
        private System.Windows.Forms.Panel panelButtons;

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
            this.dataGridViewStatus = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonfind = new System.Windows.Forms.Button();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.searchLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTopSpacing = new System.Windows.Forms.Panel();
            this.panelData = new System.Windows.Forms.Panel();
            this.panelDataGrid2 = new System.Windows.Forms.Panel();
            this.panelSpacing = new System.Windows.Forms.Panel();
            this.panelDataGrid1 = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.searchLayout.SuspendLayout();
            this.panelData.SuspendLayout();
            this.panelDataGrid2.SuspendLayout();
            this.panelDataGrid1.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewStatus
            // 
            this.dataGridViewStatus.AllowUserToAddRows = false;
            this.dataGridViewStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStatus.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStatus.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewStatus.Name = "dataGridViewStatus";
            this.dataGridViewStatus.RowHeadersVisible = false;
            this.dataGridViewStatus.Size = new System.Drawing.Size(1025, 180);
            this.dataGridViewStatus.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1025, 180);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonfind
            // 
            this.buttonfind.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonfind.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonfind.FlatAppearance.BorderSize = 0;
            this.buttonfind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonfind.ForeColor = System.Drawing.Color.White;
            this.buttonfind.Location = new System.Drawing.Point(20, 20);
            this.buttonfind.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.buttonfind.Name = "buttonfind";
            this.buttonfind.Size = new System.Drawing.Size(120, 40);
            this.buttonfind.TabIndex = 2;
            this.buttonfind.Text = "Search";
            this.buttonfind.UseVisualStyleBackColor = false;
            // 
            // textBoxFind
            // 
            this.textBoxFind.Font = new System.Drawing.Font("Arial", 12F);
            this.textBoxFind.Location = new System.Drawing.Point(20, 10);
            this.textBoxFind.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(788, 26);
            this.textBoxFind.TabIndex = 1;
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonLoad.FlatAppearance.BorderSize = 0;
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoad.ForeColor = System.Drawing.Color.White;
            this.buttonLoad.Location = new System.Drawing.Point(925, 20);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(120, 40);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Reload";
            this.buttonLoad.UseVisualStyleBackColor = false;
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.LightGray;
            this.panelSearch.Controls.Add(this.searchLayout);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Padding = new System.Windows.Forms.Padding(20);
            this.panelSearch.Size = new System.Drawing.Size(1065, 100);
            this.panelSearch.TabIndex = 3;
            // 
            // searchLayout
            // 
            this.searchLayout.AutoSize = true;
            this.searchLayout.Controls.Add(this.textBoxFind);
            this.searchLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchLayout.Location = new System.Drawing.Point(20, 20);
            this.searchLayout.Name = "searchLayout";
            this.searchLayout.Padding = new System.Windows.Forms.Padding(10);
            this.searchLayout.Size = new System.Drawing.Size(1025, 60);
            this.searchLayout.TabIndex = 0;
            this.searchLayout.WrapContents = false;
            // 
            // panelTopSpacing
            // 
            this.panelTopSpacing.BackColor = System.Drawing.Color.Transparent;
            this.panelTopSpacing.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopSpacing.Location = new System.Drawing.Point(0, 100);
            this.panelTopSpacing.Name = "panelTopSpacing";
            this.panelTopSpacing.Size = new System.Drawing.Size(1065, 100);
            this.panelTopSpacing.TabIndex = 2;
            // 
            // panelData
            // 
            this.panelData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelData.Controls.Add(this.panelDataGrid2);
            this.panelData.Controls.Add(this.panelSpacing);
            this.panelData.Controls.Add(this.panelDataGrid1);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 200);
            this.panelData.Name = "panelData";
            this.panelData.Padding = new System.Windows.Forms.Padding(10);
            this.panelData.Size = new System.Drawing.Size(1065, 400);
            this.panelData.TabIndex = 1;
            // 
            // panelDataGrid2
            // 
            this.panelDataGrid2.Controls.Add(this.dataGridViewStatus);
            this.panelDataGrid2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDataGrid2.Location = new System.Drawing.Point(10, 240);
            this.panelDataGrid2.Name = "panelDataGrid2";
            this.panelDataGrid2.Padding = new System.Windows.Forms.Padding(10);
            this.panelDataGrid2.Size = new System.Drawing.Size(1045, 200);
            this.panelDataGrid2.TabIndex = 0;
            // 
            // panelSpacing
            // 
            this.panelSpacing.BackColor = System.Drawing.Color.Transparent;
            this.panelSpacing.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSpacing.Location = new System.Drawing.Point(10, 210);
            this.panelSpacing.Name = "panelSpacing";
            this.panelSpacing.Size = new System.Drawing.Size(1045, 30);
            this.panelSpacing.TabIndex = 1;
            // 
            // panelDataGrid1
            // 
            this.panelDataGrid1.Controls.Add(this.dataGridView1);
            this.panelDataGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDataGrid1.Location = new System.Drawing.Point(10, 10);
            this.panelDataGrid1.Name = "panelDataGrid1";
            this.panelDataGrid1.Padding = new System.Windows.Forms.Padding(10);
            this.panelDataGrid1.Size = new System.Drawing.Size(1045, 200);
            this.panelDataGrid1.TabIndex = 2;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.LightGray;
            this.panelButtons.Controls.Add(this.buttonfind);
            this.panelButtons.Controls.Add(this.buttonLoad);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 520);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(20);
            this.panelButtons.Size = new System.Drawing.Size(1065, 80);
            this.panelButtons.TabIndex = 0;
            // 
            // InvoicesForm
            // 
            this.ClientSize = new System.Drawing.Size(1065, 600);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelTopSpacing);
            this.Controls.Add(this.panelSearch);
            this.Name = "InvoicesForm";
            this.Text = "InvoicesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.searchLayout.ResumeLayout(false);
            this.searchLayout.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.panelDataGrid2.ResumeLayout(false);
            this.panelDataGrid1.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private FlowLayoutPanel searchLayout;
    }
}
