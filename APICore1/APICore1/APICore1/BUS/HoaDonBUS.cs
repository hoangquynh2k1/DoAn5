using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Models;
using API_Elec_Shop.DAO;

namespace API_Elec_Shop.BUS
{
    public class HoaDonBUS
    {
        HoaDonDAO db = new HoaDonDAO();
        public HoaDonBan GetById(int id)
        {
            return db.GetById(id);
        }
        public bool Create(HoaDonBan g)
        {
            return db.Create(g);
        }
        public bool Update(HoaDonBan g)
        {
            return db.Update(g);
        }
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
    }
}
