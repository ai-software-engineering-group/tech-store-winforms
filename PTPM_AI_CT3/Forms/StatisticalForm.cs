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
        private ProductBLL productBLL;
        private UserBLL userBLL;
        private EmployeeBLL employeeBLL;


        public StatisticalForm()
        {
            InitializeComponent();

            invoiceBLL = new InvoiceBLL();
            productBLL = new ProductBLL();
            userBLL = new UserBLL();
            employeeBLL = new EmployeeBLL();

            this.Load += StatisticalForm_Load;
        }

        private void StatisticalForm_Load(object sender, EventArgs e)
        {
            LoadRevenueChart(DateTime.Now.Year);
            LoadBestSellingChart();

            labelTotalStaffs.Text = employeeBLL.GetEmployees().Count.ToString();
            labelTotalUsers.Text = userBLL.Load().Count.ToString();
        }

        private void LoadRevenueChart(int year)
        {
            try
            {
                var invoices = invoiceBLL.GetInvoices();
                labelTotalOrders.Text = invoices.Count.ToString();
                labelTotalRevenue.Text = invoices.Sum(i => i.Total).ToString("##,###") + "đ";

                var monthlyRevenue = invoices
                    .Where(i => i.OrderDate.Value.Year == year)
                    .GroupBy(i => i.OrderDate.Value.Month)
                    .Select(g => new
                    {
                        Month = g.Key,
                        Revenue = g.Sum(i => i.Total)
                    })
                    .OrderBy(i => i.Month)
                    .ToList();

                chartYearRevenue.Series.Clear();

                Series series = new Series
                {
                    Name = "Revenue",
                    IsVisibleInLegend = true,
                    IsXValueIndexed = true,
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.Int32,
                    YValueType = ChartValueType.Double
                };

                foreach (var data in monthlyRevenue)
                {
                    series.Points.AddXY(data.Month, data.Revenue);
                }

                chartYearRevenue.Series.Add(series);
                chartYearRevenue.ChartAreas[0].AxisX.Title = "Tháng";
                chartYearRevenue.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
                chartYearRevenue.ChartAreas[0].AxisX.Interval = 1;

            }
            catch (Exception ex)
            {

            }
        }

        private void LoadBestSellingChart()
        {
            var products = productBLL.GetProducts();
            labelTotalProducts.Text = products.Count.ToString();

            var topProducts = products
                .Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    TotalQuantity = p.InvoiceDetails.Sum(d => d.Quantity)
                })
                .OrderByDescending(p => p.TotalQuantity)
                .Take(5)
                .ToList();

            chartBestSelling.Series.Clear();

            Series series = new Series
            {
                Name = "TopProducts",
                ChartType = SeriesChartType.Doughnut,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32
            };

            foreach (var product in topProducts)
            {
                DataPoint point = new DataPoint();
                point.SetValueXY(product.ProductId, product.TotalQuantity);
                point.Label = product.ProductId;
                point.SetCustomProperty("LegendText", product.ProductName);
                series.Points.Add(point);
            }

            chartBestSelling.Series.Add(series);

            chartBestSelling.Titles.Clear();
            chartBestSelling.Titles.Add("Top 5 sản phẩm bán chạy nhất");
            chartBestSelling.Series[0]["PieLabelStyle"] = "Inside";
            chartBestSelling.Series[0].BorderWidth = 1;
            chartBestSelling.Series[0].BorderColor = System.Drawing.Color.Black;
        }
    }
}
