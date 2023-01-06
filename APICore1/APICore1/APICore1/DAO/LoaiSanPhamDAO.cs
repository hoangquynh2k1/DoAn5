using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Models;

namespace API_Elec_Shop.DAO
{
    public class LoaiSanPhamDAO
    {
        lkshopContext db = new lkshopContext();
        public List<LoaiSp> GetLoaiSps()
        {
            return db.LoaiSps.Where(x=> x.TrangThai ==true).ToList<LoaiSp>();
        }
        public LoaiSp GetById(int id)
        {
            return db.LoaiSps.Where(x => x.Id == id && x.TrangThai == true).First();
        }
        
    }
}
