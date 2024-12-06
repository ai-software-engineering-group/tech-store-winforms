using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControls
{
    public partial class TxtPositiveNumber : TextBox
    {
        private ErrorProvider error;

        public TxtPositiveNumber()
        {
            InitializeComponent();

            error = new ErrorProvider();

            this.KeyPress += TxtPositiveNumber_KeyPress;
            this.TextChanged += TxtPositiveNumber_TextChanged;
        }

        private void TxtPositiveNumber_TextChanged(object sender, EventArgs e)
        {
            error.Clear();

            string content = ((TextBox)sender).Text;

            if (string.IsNullOrWhiteSpace(content)) return;

            if (!decimal.TryParse(content, out decimal value) || value < 0)
            {
                error.SetError(this, "Vui lòng nhập số dương");
                this.Text = "";
            }
        }

        private void TxtPositiveNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && this.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
