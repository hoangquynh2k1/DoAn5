using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Models;

namespace API_Admin_ElecShop.Entities
{
    public class DongSanPhamModel
    {
        public int Id { get; set; }
        public int? IdLoai { get; set; }
        public string TenDong { get; set; }
        public int? NamSx { get; set; }
        public string HangSx { get; set; }
        public bool? TrangThai { get; set; }
        public List<Sp> Sps { get; set; }
        public DongSanPhamModel() { }
        public DongSanPhamModel(DongSp o, List<Sp> i)
        {
            Id = o.Id;
            TenDong = o.TenDong;
            IdLoai = o.IdLoai;
            NamSx = o.NamSx;
            Sps = i;
            HangSx = o.HangSx;
            TrangThai = o.TrangThai;
        }

    }
}
