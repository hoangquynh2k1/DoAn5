using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Models;

namespace API_Admin_ElecShop.Entities
{
    public class LoaiSanPhamModel
    {
        public int Id { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public List<DongSp> dongSps { get; set; }
        public bool? TrangThai { get; set; }
        public LoaiSanPhamModel() { }
        public LoaiSanPhamModel(LoaiSp o,List<DongSp> i)
        {
            Id = o.Id;
            TenLoai = o.TenLoai;
            MoTa = o.MoTa;
            dongSps = i;
            TrangThai = o.TrangThai;
        }

    }
}
