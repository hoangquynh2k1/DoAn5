using System;
using System.Collections.Generic;

#nullable disable

namespace API_Elec_Shop.Models
{
    public partial class GioHang
    {
        public int? Id { get; set; }
        public int? IdKh { get; set; }
        public DateTime? NgayDat { get; set; }
        public bool? TrangThai { get; set; }
    }
}
