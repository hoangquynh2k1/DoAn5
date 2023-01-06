using System;
using System.Collections.Generic;

#nullable disable

namespace API_Admin_ElecShop.Models
{
    public partial class AnhSp
    {
        public int Id { get; set; }
        public int? IdSp { get; set; }
        public string DuongDan { get; set; }
        public bool? TrangThai { get; set; }
    }
}
