using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;
using System.Windows.Forms.DataVisualization.Charting;

namespace PTPM_AI_CT3.Forms
{
    public partial class StatisticalForm : Form
    {
        private readonly StatisticalBLL statisticalBLL;

        public StatisticalForm()
        {
            InitializeComponent();
            statisticalBLL = new StatisticalBLL(); // Khởi tạo lớp BLL
        }

        // Cấu hình biểu đồ
        private void SetupChart()
        {
            // Xóa các series cũ nếu có
            chartRevenue.Series.Clear();

            // Thêm một Series mới
            Series revenueSeries = new Series("Doanh thu");
            chartRevenue.Series.Add(revenueSeries);

            // Đặt kiểu biểu đồ là cột (Column)
            revenueSeries.ChartType = SeriesChartType.Column;

            // Thêm dữ liệu vào biểu đồ (sẽ được thực hiện sau khi lấy dữ liệu từ BLL)
            revenueSeries.XValueMember = "ProductName"; // Trục X: Tên sản phẩm
            revenueSeries.YValueMembers = "TotalRevenue"; // Trục Y: Tổng doanh thu

            // Cấu hình các thuộc tính của trục X và Y
            chartRevenue.ChartAreas[0].AxisX.Title = "Sản phẩm";
            chartRevenue.ChartAreas[0].AxisY.Title = "Tổng doanh thu";

            // Cấu hình hiển thị của trục Y
            chartRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "C0"; // Định dạng tiền tệ
        }

        // Hiển thị thống kê doanh thu
        private void ShowRevenueStats(DateTime startDate, DateTime endDate)
        {
            // Lấy dữ liệu thống kê doanh thu từ BLL
            var revenueStats = statisticalBLL.GetRevenueStats(startDate, endDate);

            // Thiết lập biểu đồ
            SetupChart();

            // Liên kết dữ liệu vào biểu đồ
            chartRevenue.DataSource = revenueStats;
            chartRevenue.DataBind();
        }

        // Sự kiện khi nhấn nút Xem thống kê
        private void btnViewStats_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            // Gọi phương thức để hiển thị thống kê
            ShowRevenueStats(startDate, endDate);
        }
    }
}
