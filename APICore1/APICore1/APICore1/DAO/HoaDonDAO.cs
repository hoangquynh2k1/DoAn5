using API_Elec_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Elec_Shop.DAO
{
    public class HoaDonDAO
    {
        lkshopContext db = new lkshopContext();
        public HoaDonBan GetById(int id)
        {
            var result = db.HoaDonBans.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
           
            return result;
        }
        public bool Create(HoaDonBan g)
        {
            if(g!=null)
            {
                db.HoaDonBans.Add(g);
                db.SaveChanges();
                return true;
            }    
            else
            {
                return false;
            }    
        }
        public bool Update(HoaDonBan g)
        {
            HoaDonBan gh = db.HoaDonBans.Where(x => x.Id == g.Id).FirstOrDefault();
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
            HoaDonBan gh = db.HoaDonBans.Where(x => x.Id == id).FirstOrDefault();
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
