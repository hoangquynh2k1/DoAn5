using System;
using System.Collections.Generic;

#nullable disable

namespace API_Elec_Shop.Models
{
    public partial class CtHoaDonNhap
    {
        public int Id { get; set; }
        public int? IdHoaDonNhap { get; set; }
        public int? IdKho { get; set; }
        public int? GiaNhap { get; set; }
        public bool? TrangThai { get; set; }
    }
}
