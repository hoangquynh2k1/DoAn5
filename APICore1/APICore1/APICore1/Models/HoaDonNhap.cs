using System;
using System.Collections.Generic;

#nullable disable

namespace API_Elec_Shop.Models
{
    public partial class HoaDonNhap
    {
        public int Id { get; set; }
        public int? IdNcc { get; set; }
        public int? IdNhanVien { get; set; }
        public DateTime? NgayNhap { get; set; }
        public bool? TrangThai { get; set; }
    }
}
