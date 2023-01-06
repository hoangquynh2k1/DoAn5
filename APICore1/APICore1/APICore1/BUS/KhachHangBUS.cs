using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Models;
using API_Elec_Shop.DAO;
using API_Elec_Shop.Entities;

namespace API_Elec_Shop.BUS
{
    public class KhachHangBUS
    {
       KhachHangDAO db = new KhachHangDAO();
        public KhachHangE GetById(int id)
        {
            return db.GetById(id);
        }
        public bool Create(KhachHangE g)
        {
            return db.Create(g);
        }
        public bool Update(KhachHangE g)
        {
            return db.Update(g);
        }
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
    }
}
