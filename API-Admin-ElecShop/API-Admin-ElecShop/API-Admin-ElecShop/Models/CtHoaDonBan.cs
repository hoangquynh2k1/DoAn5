using System;
using System.Collections.Generic;

#nullable disable

namespace API_Admin_ElecShop.Models
{
    public partial class CtHoaDonBan
    {
        public int Id { get; set; }
        public int? IdHoaDonBan { get; set; }
        public int? IdKho { get; set; }
        public int? Gia { get; set; }
        public bool? TrangThai { get; set; }
        public int? IdSp { get; set; }
    }
}
