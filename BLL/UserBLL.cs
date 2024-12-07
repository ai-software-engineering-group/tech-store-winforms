using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBLL
    {
        UserDAL dal;

        public UserBLL()
        {
            dal = new UserDAL();
        }

        public User GetUser(string username, string password)
        {
            return dal.GetUser(username, password);
        }

        public bool CreateUser(User user)
        {
            return dal.CreateUser(user);
        }
        public List<User> Load()
        {
            try
            {
                return dal.LoadUser();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
                return null;
            }
        }
    }
}
