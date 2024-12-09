using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class CustomersBLL
    {
        private CustomersDAL customersDAL = new CustomersDAL(); // DAL vẫn được sử dụng trong BLL

        public CustomersBLL() { }

        // Lấy danh sách khách hàng từ DAL
        public List<Customer> GetCustomers()
        {
            try
            {
                return customersDAL.LoadCustomes(); // Gọi DAL từ đây
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
                return null;
            }
        }

<<<<<<< HEAD
        public string GenerateCustomerId()
        {
            return customersDAL.GenerateCustomerId();
        }

=======
        // Thêm khách hàng
>>>>>>> 94e12daad8e6d412fb18153812a784fa48e8e1a1
        public bool AddCustomer(Customer customer)
        {
            return customersDAL.AddCustomer(customer); // Gọi DAL từ đây
        }

        // Cập nhật thông tin khách hàng
        public bool UpdateCustomer(Customer customer)
        {
            return customersDAL.UpdateCustomer(customer); // Gọi DAL từ đây
        }

        // Xóa khách hàng
        public bool DeleteCustomer(string customerId)
        {
            return customersDAL.DeleteCustomer(customerId); // Gọi DAL từ đây
        }

        // Tìm khách hàng theo mã
        public List<Customer> SearchCustomersById(string id)
        {
            return customersDAL.LoadCustomes()
                .Where(c => c.CustomerId != null && c.CustomerId.Contains(id))
                .ToList();
        }

        // Tìm khách hàng theo tên
        public List<Customer> SearchCustomersByName(string name)
        {
            return customersDAL.LoadCustomes()
                .Where(c => c.CustomerName != null && c.CustomerName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        // Tìm khách hàng theo số điện thoại
        public List<Customer> SearchCustomersByPhone(string phone)
        {
            return customersDAL.LoadCustomes()
                .Where(c => c.Phone != null && c.Phone.Contains(phone))
                .ToList();
        }

        // Tìm khách hàng theo ngày sinh
        public List<Customer> SearchCustomersByDOB(DateTime startDate, DateTime endDate)
        {
            return customersDAL.LoadCustomes()
                .Where(c => c.DOB >= startDate && c.DOB <= endDate)
                .ToList();
        }

        // Sinh mã khách hàng
        public string GenerateCustomerId()
        {
            return customersDAL.GenerateCustomerId(); // Gọi DAL để sinh mã khách hàng
        }
    }
}
