using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Models;
using API_Elec_Shop.DAO;

namespace API_Elec_Shop.BUS
{
    public class CtGioHangBUS
    {
        CtGioHangDAO db1 = new CtGioHangDAO();
        public CtGioHang GetById(int id)
        {
            return db1.GetById(id);
        }
        public List<CtGioHang> GetByIdGio(int id)
        {
            return db1.GetByIdGio(id);
        }
        public bool Create(CtGioHang g)
        {
            return db1.Create(g);
        }
        public bool Update(CtGioHang g)
        {
            return db1.Update(g);
        }
        public bool Delete(int id)
        {
            return db1.Delete(id);
        }
    }
}
