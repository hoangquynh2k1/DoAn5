using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Models;
using API_Elec_Shop.DAO;
using API_Elec_Shop.Entities;

namespace API_Elec_Shop.BUS
{
    public class GioHangBUS
    {
       GioHangDAO db = new GioHangDAO();
        public GioHangE GetById(int id)
        {
            return db.GetById(id);
        }
        public GioHangE GetByIdKh(int id)
        {
            return db.GetByIdKh(id);
        }
        public bool Create(GioHangE g)
        {
            return db.Create(g);
        }
        public bool Update(GioHangE g)
        {
            return db.Update(g);
        }
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
    }
}
