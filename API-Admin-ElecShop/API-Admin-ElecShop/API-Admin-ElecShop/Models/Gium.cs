using System;
using System.Collections.Generic;

#nullable disable

namespace API_Admin_ElecShop.Models
{
    public partial class Gium
    {
        public int? Id { get; set; }
        public int? IdSp { get; set; }
        public int? GiaBan { get; set; }
        public DateTime? NgayAd { get; set; }
        public DateTime? NgayKt { get; set; }
        public bool? TrangThai { get; set; }
    }
}
