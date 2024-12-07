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

namespace PTPM_AI_CT3.Forms
{
    public partial class InvoicesForm : Form
    {
        InvoiceBLL InvoiceBLL = new InvoiceBLL();

        public InvoicesForm()
        {
            InitializeComponent();
            this.Load += InvoicesForm_Load;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
        }

        private void InvoicesForm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            dataGridView1.DataSource = InvoiceBLL.GetInvoices();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            string invoiceId = dataGridView1.Rows[e.RowIndex].Cells["InvoiceId"].Value.ToString();

            if (columnName == "IsAccepted")
            {
                bool isAccepted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["IsAccepted"].Value);
                UpdateAcceptedStatus(invoiceId, isAccepted);
            }
            else if (columnName == "IsCompleted")
            {
                bool isCompleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["IsCompleted"].Value);
                UpdateCompletedStatus(invoiceId, isCompleted);
            }
            else if (columnName == "IsCancelled")
            {
                bool isCancelled = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["IsCancelled"].Value);
                UpdateCancelledStatus(invoiceId, isCancelled);
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void UpdateAcceptedStatus(string invoiceId, bool isAccepted)
        {
            bool result = InvoiceBLL.UpdateAcceptedStatusAndInvoiceStatus(invoiceId, isAccepted);

            if (result)
            {
                MessageBox.Show("Cập nhật trạng thái xác nhận thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái xác nhận thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCompletedStatus(string invoiceId, bool isCompleted)
        {
            bool result = InvoiceBLL.UpdateCompletedStatusAndInvoiceStatus(invoiceId, isCompleted);

            if (result)
            {
                MessageBox.Show("Cập nhật trạng thái hoàn thành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái hoàn thành thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCancelledStatus(string invoiceId, bool isCancelled)
        {
            bool result = InvoiceBLL.UpdateCancelledStatus(invoiceId, isCancelled);

            if (result)
            {
                MessageBox.Show("Cập nhật trạng thái hủy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái hủy thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
