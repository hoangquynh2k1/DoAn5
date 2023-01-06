using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Models;

namespace API_Admin_ElecShop.Entities
{
    public class HoaDonNhapModel
    {
        public int Id { get; set; }
        public int? IdNcc { get; set; }
        public int? IdNhanVien { get; set; }
        public DateTime? NgayNhap { get; set; }
        public bool? TrangThai { get; set; }
        public List<CtHoaDonNhap> CtHoaDonNhaps { get; set; }
        public HoaDonNhapModel()
        {

        }
        public HoaDonNhapModel(HoaDonNhap h, List<CtHoaDonNhap> ct)
        {
            Id = h.Id;
            IdNcc = h.IdNcc;
            IdNhanVien = h.IdNhanVien;
            NgayNhap = h.NgayNhap;
            TrangThai = h.TrangThai;
            CtHoaDonNhaps = ct;
        }
    }
}
