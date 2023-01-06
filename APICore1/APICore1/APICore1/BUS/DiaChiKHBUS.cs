using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.DAO;
using API_Elec_Shop.Models;

namespace API_Elec_Shop.BUS
{
    public class DiaChiKHBUS
    {
        DiaChiKHDAO db = new DiaChiKHDAO();
        public List<DiaChi> GetAll()
        {
            return db.GetAll();
        }
        public DiaChi GetById(int id)
        {
            return db.GetById(id);
        }
        public List<DiaChi> GetByIdKH(int id)
        {
            return db.GetByIdKH(id);
        }
    }
}
