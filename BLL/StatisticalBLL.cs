using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class StatisticalBLL
    {
        private StatisticalDAL dal;

        public StatisticalBLL()
        {
            dal = new StatisticalDAL();
        }
        // Phương thức lấy thống kê doanh thu
        public List<RevenueStatDTO> GetRevenueStats(DateTime startDate, DateTime endDate)
        {
            return dal.GetRevenueStats(startDate, endDate);
        }
    }
}
