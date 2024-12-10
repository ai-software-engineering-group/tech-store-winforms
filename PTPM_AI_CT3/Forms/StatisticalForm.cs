using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Drawing;

namespace PTPM_AI_CT3.Forms
{
    public partial class StatisticalForm : Form
    {
        private InvoiceBLL invoiceBLL;

        public StatisticalForm()
        {
            InitializeComponent();
            invoiceBLL = new InvoiceBLL();
            InitializeMonthComboBox(); 
            LoadData(DateTime.Now.Month, DateTime.Now.Year); 
        }

        private void InitializeMonthComboBox()
        {
            cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 1; i <= 12; i++)
            {
                cmbMonth.Items.Add(i);
            }

            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;

            cmbMonth.SelectedIndexChanged += cmbMonth_SelectedIndexChanged;
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonth.SelectedItem != null)
            {
                int selectedMonth = Convert.ToInt32(cmbMonth.SelectedItem);
                int selectedYear = DateTime.Now.Year; 

                LoadData(selectedMonth, selectedYear);
            }
        }

        private void LoadData(int selectedMonth, int selectedYear)
        {
            var totalProducts = invoiceBLL.GetMonthlyProductsSold(selectedMonth, selectedYear);
            lblTotalProducts.Text = totalProducts.ToString();

            var totalSales = invoiceBLL.GetMonthlySales(selectedMonth, selectedYear);
            lblTotalSales.Text = string.Format(new CultureInfo("vi-VN"), "{0:C0}", totalSales);

            var totalOrders = invoiceBLL.GetMonthlyOrders(selectedMonth, selectedYear);
            lblTotalOrders.Text = totalOrders.ToString();

            LoadSalesChart(selectedMonth, selectedYear);

            var topSellingProducts = invoiceBLL.GetTopSellingProducts(selectedMonth, selectedYear);
            dgvTopSellingProducts.DataSource = topSellingProducts;

            var activeUsers = invoiceBLL.GetActiveUsers();
            dgvActiveUsers.DataSource = activeUsers;
        }

        private void LoadSalesChart(int selectedMonth, int selectedYear)
        {
            var salesData = invoiceBLL.GetSalesDataForChart(selectedYear);

            foreach (var data in salesData)
            {
                Console.WriteLine($"Month: {data.Date.Month}, TotalSales: {data.TotalSales}, TotalOrders: {data.TotalOrders}");
            }

            var months = Enumerable.Range(1, 12).ToList();

            chartSales.Series.Clear();

            var revenueSeries = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = Color.Blue
            };


            foreach (var month in months)
            {
                var dataForMonth = salesData.FirstOrDefault(data => data.Date.Month == month);
                var totalSales = dataForMonth?.TotalSales ?? 0;
                var totalOrders = dataForMonth?.TotalOrders ?? 0;

                revenueSeries.Points.AddXY(month.ToString("00") + "/" + selectedYear, totalSales);
            }

            chartSales.Series.Add(revenueSeries);

            chartSales.ChartAreas[0].AxisX.Interval = 1;
            chartSales.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartSales.ChartAreas[0].AxisX.Title = "Tháng";
            chartSales.ChartAreas[0].AxisY.Title = "Giá trị (VND)";
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {
       
        }

        private void lblTotalOrders_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbMonth_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
