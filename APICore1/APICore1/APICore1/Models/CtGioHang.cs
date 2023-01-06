using System;
using System.Collections.Generic;

#nullable disable

namespace API_Elec_Shop.Models
{
    public partial class CtGioHang
    {
        public int Id { get; set; }
        public int? IdGioHang { get; set; }
        public int? IdKho { get; set; }
        public int? Gia { get; set; }
        public bool? TrangThai { get; set; }
        public int? IdSp { get; set; }
    }
}
