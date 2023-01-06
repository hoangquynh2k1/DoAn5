using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Models;

namespace API_Elec_Shop.DAO
{
    public class DiaChiKHDAO
    {
        lkshopContext db = new lkshopContext();
        public List<DiaChi> GetAll()
        {
            return db.DiaChis.Where(x=> x.TrangThai ==true).ToList();
        }
        public DiaChi GetById(int id)
        {
            return db.DiaChis.Where(x => x.Id == id && x.TrangThai == true).First();
        }
        public List<DiaChi> GetByIdKH(int id)
        {
            List<DiaChi> tk = db.DiaChis.Where(x=> x.IdKh ==id && x.TrangThai ==true).ToList();
            return tk;
        }
    }
}
