using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.DAO;
using API_Elec_Shop.Models;

namespace API_Elec_Shop.BUS
{
    public class LoaiSanPhamBUS
    {
        LoaiSanPhamDAO db = new LoaiSanPhamDAO();
        public List<LoaiSp> GetAll()
        {
            return db.GetLoaiSps();
        }
        public LoaiSp GetById(int id)
        {
            return db.GetById(id);
        }
    }
}
