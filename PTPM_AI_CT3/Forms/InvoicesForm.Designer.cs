using System.Drawing;
using System.Windows.Forms;

namespace PTPM_AI_CT3.Forms
{
    partial class InvoicesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelTopSpacing;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Panel panelDataGrid1;
        private System.Windows.Forms.Panel panelDataGrid2;

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
            this.panelTopSpacing = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonfind = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.panelData = new System.Windows.Forms.Panel();
            this.panelDataGrid2 = new System.Windows.Forms.Panel();
            this.panelDataGrid1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelTopSpacing.SuspendLayout();
            this.panelData.SuspendLayout();
            this.panelDataGrid2.SuspendLayout();
            this.panelDataGrid1.SuspendLayout();
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
            this.dataGridView1.Size = new System.Drawing.Size(1025, 279);
            this.dataGridView1.TabIndex = 0;
            // 
            // panelTopSpacing
            // 
            this.panelTopSpacing.BackColor = System.Drawing.Color.Transparent;
            this.panelTopSpacing.Controls.Add(this.label1);
            this.panelTopSpacing.Controls.Add(this.buttonfind);
            this.panelTopSpacing.Controls.Add(this.buttonLoad);
            this.panelTopSpacing.Controls.Add(this.textBoxFind);
            this.panelTopSpacing.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopSpacing.Location = new System.Drawing.Point(0, 0);
            this.panelTopSpacing.Name = "panelTopSpacing";
            this.panelTopSpacing.Size = new System.Drawing.Size(1065, 52);
            this.panelTopSpacing.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tìm theo mã hóa đơn";
            // 
            // buttonfind
            // 
            this.buttonfind.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonfind.FlatAppearance.BorderSize = 0;
            this.buttonfind.ForeColor = System.Drawing.Color.White;
            this.buttonfind.Location = new System.Drawing.Point(507, 10);
            this.buttonfind.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.buttonfind.Name = "buttonfind";
            this.buttonfind.Size = new System.Drawing.Size(80, 30);
            this.buttonfind.TabIndex = 5;
            this.buttonfind.Text = "Tìm";
            this.buttonfind.UseVisualStyleBackColor = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonLoad.FlatAppearance.BorderSize = 0;
            this.buttonLoad.ForeColor = System.Drawing.Color.White;
            this.buttonLoad.Location = new System.Drawing.Point(600, 10);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(80, 30);
            this.buttonLoad.TabIndex = 4;
            this.buttonLoad.Text = "Làm mới";
            this.buttonLoad.UseVisualStyleBackColor = false;
            // 
            // textBoxFind
            // 
            this.textBoxFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFind.Location = new System.Drawing.Point(138, 16);
            this.textBoxFind.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(309, 20);
            this.textBoxFind.TabIndex = 3;
            // 
            // panelData
            // 
            this.panelData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelData.Controls.Add(this.panelDataGrid2);
            this.panelData.Controls.Add(this.panelDataGrid1);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 52);
            this.panelData.Name = "panelData";
            this.panelData.Padding = new System.Windows.Forms.Padding(10);
            this.panelData.Size = new System.Drawing.Size(1065, 548);
            this.panelData.TabIndex = 1;
            // 
            // panelDataGrid2
            // 
            this.panelDataGrid2.Controls.Add(this.dataGridViewStatus);
            this.panelDataGrid2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDataGrid2.Location = new System.Drawing.Point(10, 309);
            this.panelDataGrid2.Name = "panelDataGrid2";
            this.panelDataGrid2.Padding = new System.Windows.Forms.Padding(10);
            this.panelDataGrid2.Size = new System.Drawing.Size(1045, 200);
            this.panelDataGrid2.TabIndex = 0;
            // 
            // panelDataGrid1
            // 
            this.panelDataGrid1.Controls.Add(this.dataGridView1);
            this.panelDataGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDataGrid1.Location = new System.Drawing.Point(10, 10);
            this.panelDataGrid1.Name = "panelDataGrid1";
            this.panelDataGrid1.Padding = new System.Windows.Forms.Padding(10);
            this.panelDataGrid1.Size = new System.Drawing.Size(1045, 299);
            this.panelDataGrid1.TabIndex = 2;
            // 
            // InvoicesForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1065, 600);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelTopSpacing);
            this.Name = "InvoicesForm";
            this.Text = "Đơn hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelTopSpacing.ResumeLayout(false);
            this.panelTopSpacing.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.panelDataGrid2.ResumeLayout(false);
            this.panelDataGrid1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private TextBox textBoxFind;
        private Button buttonfind;
        private Button buttonLoad;
        private Label label1;
    }
}
