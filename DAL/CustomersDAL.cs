using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using DTO;
using System.Windows.Forms;

namespace DAL
{
    public class CustomersDAL
    {
        STechDBDataContext db = new STechDBDataContext();

        public CustomersDAL() { }

        public List<Customer> LoadCustomes()
        {
            try
            {
                if (db == null)
                {
                    throw new InvalidOperationException("Chưa có dữ liệu");
                }

                var customersList = db.Customers.ToList();
                return customersList ?? new List<Customer>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<Customer>();
            }
        }

        public string GenerateCustomerId()
        {
            var lastCustomer = db.Customers.OrderByDescending(c => c.CustomerId).FirstOrDefault();
            int newId = 1;

            if (lastCustomer != null)
            {
                // Lấy ID cuối cùng và tạo ID mới
                string lastId = lastCustomer.CustomerId.Substring(2); // Loại bỏ "KH" để lấy phần số
                if (int.TryParse(lastId, out int id))
                {
                    newId = id + 1; // Tăng ID lên 1
                }
            }

            return "KH" + newId.ToString("D4"); // "KH" + mã khách hàng mới, với 4 chữ số
        }

        // Thêm khách hàng
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
