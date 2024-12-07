using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BLL
{
    public class Menu1BLL
    {
        Menu1DAL menu1DAL = new Menu1DAL();
        public Menu1BLL() { }
        public List<MenuLevel1> GetMenus1()
        {
            try
            {
                return menu1DAL.LoadMenus1();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
                return null;
            }
        }
        public void AddMenu1(MenuLevel1 menu)
        {
            try
            {
                menu1DAL.AddMenu1(menu);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm danh mục: " + ex.Message);
            }
        }

        public void DeleteMenu1(int id)
        {
            menu1DAL.DeleteMenu1(id);
        }

        public void UpdateMenu1(MenuLevel1 menu)
        {
            menu1DAL.UpdateMenu1(menu);
        }
    }
}
