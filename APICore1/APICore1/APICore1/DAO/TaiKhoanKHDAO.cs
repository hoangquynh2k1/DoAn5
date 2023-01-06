using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Models;

namespace API_Elec_Shop.DAO
{
    public class TaiKhoanKHDAO
    {
        lkshopContext db = new lkshopContext();
        public List<TaiKhoanKh> GetAll()
        {
            return db.TaiKhoanKhs.Where(x=> x.TrangThai ==true).ToList<TaiKhoanKh>();
        }
        public TaiKhoanKh GetById(int id)
        {
            return db.TaiKhoanKhs.Where(x => x.Id == id && x.TrangThai == true).First();
        }
        public TaiKhoanKh Login(string username, string password)
        {
            TaiKhoanKh tk = db.TaiKhoanKhs.Where(x => x.Username == username 
            && x.Password == password).FirstOrDefault();
            return tk;
        }
    }
}
