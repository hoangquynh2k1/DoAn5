using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.DAO;
using API_Elec_Shop.Models;
using API_Elec_Shop.Entities;

namespace API_Elec_Shop.BUS
{
    public class SanPhamBUS
    {
        SanPhamDAO SanPham = new SanPhamDAO();
        public List<SanPham> GetAll()
        {
            return  SanPham.GetSps();
        }
        public List<SanPham> GetByIdDong(int id)
        {
            return SanPham.GetByIdDong(id);
        }
        public SanPham GetById(int id)
        {
            return SanPham.GetById(id);
        }
    }
}
