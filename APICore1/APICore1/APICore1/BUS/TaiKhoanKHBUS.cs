using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.DAO;
using API_Elec_Shop.Models;

namespace API_Elec_Shop.BUS
{
    public class TaiKhoanKHBUS
    {
        TaiKhoanKHDAO db = new TaiKhoanKHDAO();
        public List<TaiKhoanKh> GetAll()
        {
            return db.GetAll();
        }
        public TaiKhoanKh GetById(int id)
        {
            return db.GetById(id);
        }
        public TaiKhoanKh Login(string un,string pw)
        {
            return db.Login(un, pw);
        }
    }
}
