using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using System.Windows.Forms;
using DAL.Extensions;

namespace DAL
{
    public class CustomersDAL
    {
        private STechDBDataContext db = new STechDBDataContext();

        public CustomersDAL() { }

        // Lấy danh sách khách hàng
        public List<Customer> LoadCustomes()
        {
            try
            {
                var customersList = db.Customers.ToList();
                return customersList ?? new List<Customer>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<Customer>();
            }
        }

        // Sinh mã khách hàng mới
        public string GenerateCustomerId()
        {
           return DateTime.Now.ToString("yyyyMMdd") + RandomUtils.GenerateRandomString(8).ToUpper();
        }

        // Thêm khách hàng vào cơ sở dữ liệu
        public bool AddCustomer(Customer customer)
        {
            try
            {
                customer.CustomerId = GenerateCustomerId(); // Tạo mã khách hàng mới
                db.Customers.InsertOnSubmit(customer);
                db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                return false;
            }
        }

        // Cập nhật thông tin khách hàng
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var existingCustomer = db.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
                if (existingCustomer != null)
                {
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Phone = customer.Phone;
                    existingCustomer.Email = customer.Email;
                    existingCustomer.DOB = customer.DOB;
                    existingCustomer.Gender = customer.Gender;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.Ward = customer.Ward;
                    existingCustomer.District = customer.District;
                    existingCustomer.Province = customer.Province;
                    existingCustomer.WardCode = customer.WardCode;
                    existingCustomer.DistrictCode = customer.DistrictCode;
                    existingCustomer.ProvinceCode = customer.ProvinceCode;

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
        public bool DeleteCustomer(string customerId)
        {
            try
            {
                var customer = db.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                if (customer != null)
                {
                    db.Customers.DeleteOnSubmit(customer);
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
