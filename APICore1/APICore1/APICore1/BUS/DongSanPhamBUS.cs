using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.DAO;
using API_Elec_Shop.Models;

namespace API_Elec_Shop.BUS
{
    public class DongSanPhamBUS
    {
        DongSanPhamDAO db = new DongSanPhamDAO();
        public List<DongSp> GetAll()
        {
            return db.GetDongSps();
        }
        public List<DongSp> GetByIdLoai(int id)
        {
            return db.GetByIdLoai(id);
        }
        public DongSp GetById(int id)
        {
            return db.GetById(id);
        }
    }
}
