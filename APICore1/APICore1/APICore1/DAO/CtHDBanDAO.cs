using API_Elec_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Elec_Shop.DAO
{
    public class CtHoaDonBanDAO
    {
        lkshopContext db = new lkshopContext();
        public CtHoaDonBan GetById(int id)
        {
            var result = db.CtHoaDonBans.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            return result;
        }
        public bool Create(CtHoaDonBan g)
        {
            if(g!=null)
            {
                db.CtHoaDonBans.Add(g);
                db.SaveChanges();
                return true;
            }    
            else
            {
                return false;
            }    
        }
        public bool Update(CtHoaDonBan g)
        {
            CtHoaDonBan gh = db.CtHoaDonBans.Where(x => x.Id == g.Id).FirstOrDefault();
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
            CtHoaDonBan gh = db.CtHoaDonBans.Where(x => x.Id == id).FirstOrDefault();
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
