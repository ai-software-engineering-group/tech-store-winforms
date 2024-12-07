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
    public class Menu2DAL
    {
        STechDBDataContext db = new STechDBDataContext();
        public Menu2DAL() { }
        public List<MenuLevel2> LoadMenus2()
        {
            try
            {
                if (db == null)
                {
                    throw new InvalidOperationException("Chưa có dữ liệu");
                }

                var menu2List = db.MenuLevel2s.ToList();
                return menu2List ?? new List<MenuLevel2>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<MenuLevel2>();
            }
        }
        public void AddMenu2(MenuLevel2 menu)
        {
            try
            {
                db.MenuLevel2s.InsertOnSubmit(menu);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm danh mục: " + ex.Message);
            }
        }

        public void DeleteMenu2(int id)
        {
            var menu2 = db.MenuLevel2s.FirstOrDefault(m => m.Id == id);
            if (menu2 != null)
            {
                db.MenuLevel2s.DeleteOnSubmit(menu2);
                db.SubmitChanges();
            }
        }

        public void UpdateMenu2(MenuLevel2 menu)
        {
            var existingMenu = db.MenuLevel2s.FirstOrDefault(m => m.Id == menu.Id);
            if (existingMenu != null)
            {
                existingMenu.MenuName = menu.MenuName;
                existingMenu.RedirectUrl = menu.RedirectUrl;
                existingMenu.MenuLevel1Id = menu.MenuLevel1Id;
                db.SubmitChanges();
            }
        }
    }
}
