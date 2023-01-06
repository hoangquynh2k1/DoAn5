using API_Elec_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Elec_Shop.DAO
{
    public class CtGioHangDAO
    {
        lkshopContext db = new lkshopContext();
        public CtGioHang GetById(int id)
        {
            var result = db.CtGioHangs.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            return result;
        }
        public List<CtGioHang> GetByIdGio(int id)
        {
            var result = db.CtGioHangs.Where(x => x.IdGioHang == id && x.TrangThai == true).ToList<CtGioHang>();
            return result;
        }
        public bool Create(CtGioHang g)
        {
            if(g!=null)
            {
                db.CtGioHangs.Add(g);
                db.SaveChanges();
                return true;
            }    
            else
            {
                return false;
            }    
        }
        public bool Update(CtGioHang g)
        {
            CtGioHang gh = db.CtGioHangs.Where(x => x.Id == g.Id).FirstOrDefault();
            if (gh != null)
            {
                gh = g;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            CtGioHang gh = db.CtGioHangs.Where(x => x.Id == id).FirstOrDefault();
            if (gh != null)
            {
                gh.TrangThai = false;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
