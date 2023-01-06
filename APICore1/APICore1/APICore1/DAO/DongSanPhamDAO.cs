using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Models;

namespace API_Elec_Shop.DAO
{
    public class DongSanPhamDAO
    {
        lkshopContext db = new lkshopContext();
        public List<DongSp> GetDongSps()
        {
            return db.DongSps.Where(x=> x.TrangThai ==true).ToList<DongSp>();
        }
        public DongSp GetById(int id)
        {
            return db.DongSps.Where(x => x.Id == id && x.TrangThai == true).First();
        }
        public List<DongSp> GetByIdLoai(int id)
        {
            return db.DongSps.Where(x => x.IdLoai == id && x.TrangThai == true)
                .ToList<DongSp>();
        }
    }
}
