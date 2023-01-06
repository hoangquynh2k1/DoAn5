using System;
using System.Collections.Generic;

#nullable disable

namespace API_Admin_ElecShop.Models
{
    public partial class GioHang
    {
        public int Id { get; set; }
        public int? IdKh { get; set; }
        public DateTime? NgayDat { get; set; }
        public bool? TrangThai { get; set; }
    }
}
