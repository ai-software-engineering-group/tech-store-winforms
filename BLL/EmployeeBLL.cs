using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeBLL
    {
        private EmployeeDAL dal;
        public EmployeeBLL()
        {
            dal = new EmployeeDAL();
        }
        public List<Employee> GetEmployees()
        {
            try
            {
                return dal.LoadEmployee();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
                return null;
            }
        }
        public bool AddEmployee(Employee employee)
        {
            return dal.AddEmployee(employee);
        }

        public bool UpdateEmployee(Employee employee)
        {
            return dal.UpdateEmployee(employee);
        }

        public bool DeleteEmployee(string employeeId)
        {
            return dal.DeleteEmployee(employeeId);
        }
        public List<Employee> SearchEmployeesById(string id)
        {
            return dal.LoadEmployee()
                .Where(c => c.EmployeeId != null && c.EmployeeId.Contains(id))
                .ToList();
        }

        public List<Employee> SearchEmployeeByName(string name)
        {
            return dal.LoadEmployee()
                .Where(c => c.EmployeeName != null &&
                            c.EmployeeName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public List<Employee> SearchEmployeeByPhone(string phone)
        {
            return dal.LoadEmployee()
                .Where(c => c.Phone != null && c.Phone.Contains(phone))
                .ToList();
        }

        public List<Employee> SearchEmployeeByDOB(DateTime startDate, DateTime endDate)
        {
            return dal.LoadEmployee()
                .Where(c => c.DOB >= startDate && c.DOB <= endDate)
                .ToList();
        }
    }
}
