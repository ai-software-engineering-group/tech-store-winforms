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
    public class Menu1DAL
    {
        STechDBDataContext db = new STechDBDataContext();
        public Menu1DAL() { }
        public List<MenuLevel1> LoadMenus1()
        {
            try
            {
                if (db == null)
                {
                    throw new InvalidOperationException("Chưa có dữ liệu");
                }

                var menu1List = db.MenuLevel1s.ToList();
                return menu1List ?? new List<MenuLevel1>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<MenuLevel1>();
            }
        }
        public void AddMenu1(MenuLevel1 menu)
        {
            try
            {
                db.MenuLevel1s.InsertOnSubmit(menu);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm danh mục: " + ex.Message);
            }
        }

        public void DeleteMenu1(int id)
        {
            var menu1 = db.MenuLevel1s.FirstOrDefault(m => m.Id == id);
            if (menu1 != null)
            {
                db.MenuLevel1s.DeleteOnSubmit(menu1);
                db.SubmitChanges();
            }
        }

        public void UpdateMenu1(MenuLevel1 menu)
        {
            var existingMenu = db.MenuLevel1s.FirstOrDefault(m => m.Id == menu.Id);
            if (existingMenu != null)
            {
                existingMenu.MenuName = menu.MenuName;
                existingMenu.RedirectUrl = menu.RedirectUrl;
                existingMenu.MenuId = menu.MenuId;
                db.SubmitChanges();
            }
        }

    }
}
