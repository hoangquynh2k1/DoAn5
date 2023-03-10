using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Models;

namespace API_Admin_ElecShop.Entities
{
    public class KhachHangModel
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public short? NamSinh { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public bool? GioiTinh { get; set; }
        public bool? TrangThai { get; set; }
        public List<TaiKhoanKh> taiKhoans { get; set; }
        public List<DiaChi> diaChis { get; set; }
        public KhachHangModel()
        {

        }
        public KhachHangModel(KhachHang k, List<TaiKhoanKh> t, List<DiaChi> d)
        {
            Id = k.Id;
            HoTen = k.HoTen;
            NamSinh = k.NamSinh;
            Sdt = k.Sdt;
            Email = k.Email;
            GioiTinh = k.GioiTinh;
            TrangThai = k.TrangThai;
            diaChis = d;
            taiKhoans = t;
        }
    }
}
