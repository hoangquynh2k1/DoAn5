using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Models;

namespace API_Admin_ElecShop.Entities
{
    public class SanPhamModel
    {
        public int Id { get; set; }
        public int? IdDong { get; set; }
        public string TenSp { get; set; }
        public string ThongSoKt { get; set; }
        public string MoTa { get; set; }
        public bool? TrangThai { get; set; }
        public List<AnhSp> anhs { get; set; }
        public int? gia { get; set; }
        public List<Kho> khos { get; set; }
        public SanPhamModel()
        {

        }
        public SanPhamModel(Sp sp, List<AnhSp> anhSp, Gium gia, List<Kho> khos)
        {
            Id = sp.Id;
            IdDong = sp.IdDong;
            TenSp = sp.TenSp;
            ThongSoKt = sp.ThongSoKt;
            MoTa = sp.MoTa;
            TrangThai = sp.TrangThai;
            anhs = anhSp;
            this.khos = khos;
            if (gia == null)
            {

            }
            else
                this.gia = gia.GiaBan;
        }
    }
}
