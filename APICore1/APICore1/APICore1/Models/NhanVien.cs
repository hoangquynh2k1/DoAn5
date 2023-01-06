using System;
using System.Collections.Generic;

#nullable disable

namespace API_Elec_Shop.Models
{
    public partial class NhanVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public bool? GioiTinh { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Cccd { get; set; }
        public string ChucVu { get; set; }
        public string TenNh { get; set; }
        public string Stk { get; set; }
        public bool? TrangThai { get; set; }
    }
}
