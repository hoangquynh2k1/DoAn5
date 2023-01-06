using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Entities;
using API_Admin_ElecShop.Models;

namespace API_Admin_ElecShop.DAO
{
    public class NhaCungCapDAO
    {
        lkshopContext db = new lkshopContext();
        public List<Ncc> GetList()
        {
            return db.Nccs.Where(x=>x.TrangThai==true).ToList();
        }
        public Ncc GetById(int id)
        {
            var result = db.Nccs.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();

            return result;
        }
        public bool Create(Ncc g)
        {
            if (g != null)
            {
                db.Nccs.Add(g);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(Ncc g)
        {
            Ncc gh = db.Nccs.Where(x => x.Id == g.Id).FirstOrDefault();
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
            Ncc gh = db.Nccs.Where(x => x.Id == id).FirstOrDefault();
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
