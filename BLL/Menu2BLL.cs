using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BLL
{
    public class Menu2BLL
    {
        Menu2DAL menu2DAL = new Menu2DAL();
        public Menu2BLL() { }
        public List<MenuLevel2> GetMenus2()
        {
            try
            {
                return menu2DAL.LoadMenus2();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
                return null;
            }
        }
        public void AddMenu2(MenuLevel2 menu)
        {
            try
            {
                menu2DAL.AddMenu2(menu);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm danh mục: " + ex.Message);
            }
        }

        public void DeleteMenu2(int id)
        {
            menu2DAL.DeleteMenu2(id);
        }

        public void UpdateMenu2(MenuLevel2 menu)
        {
            menu2DAL.UpdateMenu2(menu);
        }
    }
}
