using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class CustomersBLL
    {
        CustomersDAL customersDAL = new CustomersDAL();

        public CustomersBLL() { }

        public List<Customer> GetCustomers()
        {
            try
            {
                return customersDAL.LoadCustomes();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
                return null;
            }
        }

        public string GenerateCustomerId()
        {
            return customersDAL.GenerateCustomerId();
        }

        public bool AddCustomer(Customer customer)
        {
            return customersDAL.AddCustomer(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return customersDAL.UpdateCustomer(customer);
        }

        public bool DeleteCustomer(string customerId)
        {
            return customersDAL.DeleteCustomer(customerId);
        }
        public List<Customer> SearchCustomersById(string id)
        {
            return customersDAL.LoadCustomes()
                .Where(c => c.CustomerId != null && c.CustomerId.Contains(id))
                .ToList();
        }

        public List<Customer> SearchCustomersByName(string name)
        {
            return customersDAL.LoadCustomes()
                .Where(c => c.CustomerName != null &&
                            c.CustomerName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public List<Customer> SearchCustomersByPhone(string phone)
        {
            return customersDAL.LoadCustomes()
                .Where(c => c.Phone != null && c.Phone.Contains(phone))
                .ToList();
        }

        public List<Customer> SearchCustomersByDOB(DateTime startDate, DateTime endDate)
        {
            return customersDAL.LoadCustomes()
                .Where(c => c.DOB >= startDate && c.DOB <= endDate)
                .ToList();
        }

    }
}
