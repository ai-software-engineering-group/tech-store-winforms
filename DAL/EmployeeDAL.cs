using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using DTO;
using System.Windows.Forms;

namespace DAL
{
    public class EmployeeDAL
    {
        private STechDBDataContext db;

        public EmployeeDAL()
        {
            db = new STechDBDataContext();
        }

        public List<Employee> LoadEmployee()
        {
            try
            {
                if (db == null)
                {
                    throw new InvalidOperationException("Database context is not initialized.");
                }

                var employeeList = db.Employees.ToList();
                return employeeList ?? new List<Employee>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<Employee>();
            }
        }

        public string GenerateEmployeeId()
        {
            var lastEmployee = db.Employees.OrderByDescending(e => e.EmployeeId).FirstOrDefault();
            int newId = 1;

            if (lastEmployee != null)
            {
                string lastId = lastEmployee.EmployeeId.Substring(2);
                if (int.TryParse(lastId, out int id))
                {
                    newId = id + 1;
                }
            }

            return "NV" + newId.ToString("D4");
        }

        public string AddEmployee(Employee employee)
        {
            try
            {
                employee.EmployeeId = GenerateEmployeeId();
                db.Employees.InsertOnSubmit(employee);
                db.SubmitChanges();
                return employee.EmployeeId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                return null;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                var existingEmployee = db.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
                if (existingEmployee != null)
                {
                    existingEmployee.EmployeeName = employee.EmployeeName;
                    existingEmployee.Phone = employee.Phone;
                    existingEmployee.Email = employee.Email;
                    existingEmployee.DOB = employee.DOB;
                    existingEmployee.Gender = employee.Gender;
                    existingEmployee.CitizenId = employee.CitizenId;
                    existingEmployee.Address = employee.Address;
                    existingEmployee.Ward = employee.Ward;
                    existingEmployee.District = employee.District;
                    existingEmployee.Province = employee.Province;
                    existingEmployee.WardCode = employee.WardCode;
                    existingEmployee.DistrictCode = employee.DistrictCode;
                    existingEmployee.ProvinceCode = employee.ProvinceCode;

                    db.SubmitChanges(); // Save changes to the database
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating employee: " + ex.Message);
                return false;
            }
        }

        public bool DeleteEmployee(string employeeId)
        {
            try
            {
                var employee = db.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
                if (employee != null)
                {
                    db.Employees.DeleteOnSubmit(employee);
                    db.SubmitChanges(); // Save changes to the database
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting employee: " + ex.Message);
                return false;
            }
        }
    }
}
