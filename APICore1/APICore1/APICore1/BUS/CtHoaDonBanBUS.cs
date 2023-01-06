using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Models;
using API_Elec_Shop.DAO;

namespace API_Elec_Shop.BUS
{
    public class CtHoaDonBanBUS
    {
        CtHoaDonBanDAO db = new CtHoaDonBanDAO();
        public CtHoaDonBan GetById(int id)
        {
            return db.GetById(id);
        }
        public bool Create(CtHoaDonBan g)
        {
            return db.Create(g);
        }
        public bool Update(CtHoaDonBan g)
        {
            return db.Update(g);
        }
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
    }
}
