using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class EmployeeBLL
    {
        private EmployeeDAL employeeDAL;

        public EmployeeBLL()
        {
            employeeDAL = new EmployeeDAL();
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                return employeeDAL.LoadEmployee();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching employee list: " + ex.Message);
                return null;
            }
        }
<<<<<<< HEAD
        public string AddEmployee(Employee employee)
=======

        public bool AddEmployee(Employee employee)
>>>>>>> 94e12daad8e6d412fb18153812a784fa48e8e1a1
        {
            try
            {
                // You can include validation or business logic here
                return employeeDAL.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding employee: " + ex.Message);
                return false;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                return employeeDAL.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating employee: " + ex.Message);
                return false;
            }
        }

        public bool DeleteEmployee(string employeeId)
        {
            try
            {
                return employeeDAL.DeleteEmployee(employeeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting employee: " + ex.Message);
                return false;
            }
        }

        // You can add more search functions here to encapsulate DAL functionality
        public List<Employee> SearchEmployeesById(string id)
        {
            try
            {
                return employeeDAL.LoadEmployee()
                    .Where(e => e.EmployeeId != null && e.EmployeeId.Contains(id))
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching by ID: " + ex.Message);
                return new List<Employee>();
            }
        }

        public List<Employee> SearchEmployeeByName(string name)
        {
            return employeeDAL.LoadEmployee()
                .Where(c => c.EmployeeName != null &&
                            c.EmployeeName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public List<Employee> SearchEmployeeByPhone(string phone)
        {
            return employeeDAL.LoadEmployee()
                .Where(c => c.Phone != null && c.Phone.Contains(phone))
                .ToList();
        }

        public List<Employee> SearchEmployeeByDOB(DateTime startDate, DateTime endDate)
        {
            return employeeDAL.LoadEmployee()
                .Where(c => c.DOB >= startDate && c.DOB <= endDate)
                .ToList();
        }
    }
}
