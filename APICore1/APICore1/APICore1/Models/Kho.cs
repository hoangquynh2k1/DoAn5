using System;
using System.Collections.Generic;

#nullable disable

namespace API_Elec_Shop.Models
{
    public partial class Kho
    {
        public int Id { get; set; }
        public int? IdSp { get; set; }
        public byte? TinhTrang { get; set; }
        public bool? TrangThai { get; set; }
    }
}
