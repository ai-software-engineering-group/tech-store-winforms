using DAL.Utils;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {
        STechDBDataContext context;

        public UserDAL()
        {
            context = new STechDBDataContext();
        }

        public bool CreateUser(User user)
        {
            try
            {
                context.Users.InsertOnSubmit(user);
                context.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User GetUser(string username, string password)
        {
            User user = context.Users
                .Where(u => u.Username == username)
                .FirstOrDefault();

            if(user != null && user.PasswordHash != password.HashPasswordMD5(user.RandomKey))
            {
                return null;
            }

            return user;
        }
        public List<User> LoadUser()
        {
            try
            {
                if (context == null)
                {
                    throw new InvalidOperationException("Chưa có dữ liệu");
                }

                var userList = context.Users.ToList();
                return userList ?? new List<User>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<User>();
            }
        }
    }
}
