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
                    throw new InvalidOperationException("Chưa có dữ liệu");
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
            var lastEmployee = db.Employees.OrderByDescending(c => c.EmployeeId).FirstOrDefault();
            int newId = 1;

            if (lastEmployee != null)
            {
                // Lấy ID cuối cùng và tạo ID mới
                string lastId = lastEmployee.EmployeeId.Substring(2); // Loại bỏ "KH" để lấy phần số
                if (int.TryParse(lastId, out int id))
                {
                    newId = id + 1; // Tăng ID lên 1
                }
            }

            return "NV" + newId.ToString("D4"); // "KH" + mã khách hàng mới, với 4 chữ số
        }

        // Thêm khách hàng
        public bool AddEmployee(Employee employee)
        {
            try
            {
                employee.EmployeeId = GenerateEmployeeId(); // Tạo mã khách hàng mới
                db.Employees.InsertOnSubmit(employee);
                db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                return false;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {

                var existingEmployee = db.Employees.FirstOrDefault(c => c.EmployeeId == employee.EmployeeId);
                if (existingEmployee != null)
                {
                    existingEmployee.EmployeeId = employee.EmployeeName;
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

                    db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa khách hàng: " + ex.Message);
                return false;
            }
        }


        // Xóa khách hàng
        public bool DeleteEmployee(string employId)
        {
            try
            {
                var employee = db.Employees.FirstOrDefault(c => c.EmployeeId == employId);
                if (employId != null)
                {
                    db.Employees.DeleteOnSubmit(employee);
                    db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
                return false;
            }
        }
    }
}
