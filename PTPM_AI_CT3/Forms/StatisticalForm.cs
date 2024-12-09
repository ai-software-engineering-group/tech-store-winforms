using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace PTPM_AI_CT3.Forms
{
    public partial class StatisticalForm : Form
    {
        private InvoiceBLL invoiceBLL;

        public StatisticalForm()
        {
            InitializeComponent();
            invoiceBLL = new InvoiceBLL();
            LoadData();
        }

        private void LoadData()
        {
            // Hiển thị tổng doanh thu
            var totalSales = invoiceBLL.GetTotalSales();

            // Đảm bảo định dạng VND
            var vietnamCulture = new CultureInfo("vi-VN");
            lblTotalSales.Text = string.Format(vietnamCulture, "{0:C0}", totalSales);

            // Hiển thị tổng số đơn hàng
            var totalOrders = invoiceBLL.GetTotalOrders();
            lblTotalOrders.Text = totalOrders.ToString();
            LoadSalesChart();
            // Hiển thị sản phẩm bán chạy
            var topSellingProducts = invoiceBLL.GetTopSellingProducts();
            dgvTopSellingProducts.DataSource = topSellingProducts;

            // Hiển thị người dùng hoạt động
            var activeUsers = invoiceBLL.GetActiveUsers();
            dgvActiveUsers.DataSource = activeUsers;
        }
        private void LoadSalesChart()
        {
            // Tạo một biểu đồ đơn giản cho doanh thu theo thời gian
            var salesData = invoiceBLL.GetSalesDataForChart(); // Thêm hàm này trong BLL để lấy dữ liệu doanh thu theo tháng

            chartSales.Series.Clear();
            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh thu")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            };

            foreach (var data in salesData)
            {
                series.Points.AddXY(data.Date, data.TotalSales);
            }

            chartSales.Series.Add(series);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotalOrders_Click(object sender, EventArgs e)
        {

        }
    }
}
