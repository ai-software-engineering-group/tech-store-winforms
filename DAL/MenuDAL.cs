using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DTO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DAL
{
    public class MenuDAL
    {
        STechDBDataContext db = new STechDBDataContext();
        public MenuDAL() { }
        public List<DTO.Menu> LoadMenus()
        {
            try
            {
                if (db == null)
                {
                    throw new InvalidOperationException("Chưa có dữ liệu");
                }

                var menuList = db.Menus.ToList();
                return menuList ?? new List<DTO.Menu>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<DTO.Menu>();
            }
        }
        public int GetLastMenuId()
        {
            var lastMenu = db.Menus.OrderByDescending(m => m.Id).FirstOrDefault();
            return lastMenu?.Id ?? 0; // Nếu không có dữ liệu trả về 0
        }

        // Phương thức thêm menu mới
        public void AddMenu(DTO.Menu menu)
        {
            try
            {
                db.Menus.InsertOnSubmit(menu);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Phương thức xóa menu
        public void DeleteMenu(int id)
        {
            var menu = db.Menus.FirstOrDefault(m => m.Id == id);
            if (menu != null)
            {
                db.Menus.DeleteOnSubmit(menu);
                db.SubmitChanges();
            }
        }

        // Phương thức sửa menu
        public void UpdateMenu(DTO.Menu menu)
        {
            var existingMenu = db.Menus.FirstOrDefault(m => m.Id == menu.Id);
            if (existingMenu != null)
            {
                existingMenu.MenuName = menu.MenuName;
                existingMenu.RedirectUrl = menu.RedirectUrl;
                existingMenu.MenuIcon = menu.MenuIcon;
                db.SubmitChanges();
            }
        }
    }
}
