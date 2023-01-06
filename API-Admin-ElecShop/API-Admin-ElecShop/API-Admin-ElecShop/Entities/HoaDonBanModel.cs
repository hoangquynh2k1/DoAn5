using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Models;

namespace API_Admin_ElecShop.Entities
{
    public class HoaDonBanModel
    {
        public int Id { get; set; }
        public int? IdKh { get; set; }
        public int? IdDiaChi { get; set; }
        public DateTime? NgayDat { get; set; }
        public short? TinhTrangDh { get; set; }
        public bool? TrangThai { get; set; }
        public List<CtHoaDonBan> CtHoaDonBans { get; set; }
        public HoaDonBanModel()
        {

        }
        public HoaDonBanModel(HoaDonBan h, List<CtHoaDonBan> ct)
        {
            Id = h.Id;
            IdKh = h.IdKh;
            IdDiaChi = h.IdDiaChi;
            NgayDat = h.NgayDat;
            TinhTrangDh = h.TinhTrangDh;
            TrangThai = h.TrangThai;
            CtHoaDonBans = ct;
        }
    }
}
