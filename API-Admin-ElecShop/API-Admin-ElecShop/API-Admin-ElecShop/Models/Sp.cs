using System;
using System.Collections.Generic;

#nullable disable

namespace API_Admin_ElecShop.Models
{
    public partial class Sp
    {
        public int Id { get; set; }
        public int? IdDong { get; set; }
        public string TenSp { get; set; }
        public string ThongSoKt { get; set; }
        public string MoTa { get; set; }
        public bool? TrangThai { get; set; }
    }
}
