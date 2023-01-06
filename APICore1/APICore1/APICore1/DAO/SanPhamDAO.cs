using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Elec_Shop.Models;
using API_Elec_Shop.Entities;

namespace API_Elec_Shop.DAO
{
    public class SanPhamDAO
    {
        lkshopContext db = new lkshopContext();
        public List<SanPham> GetSps()
        {
            List<SanPham> sanPhams = new List<SanPham>();
            List<Sp> sps= db.Sps.Where(x => x.TrangThai == true).ToList();
            for(int i =0;i<sps.Count;i++)
            {
                List<AnhSp> anhs = db.AnhSps.Where(x => x.IdSp == sps[i].Id && x.TrangThai == true).ToList();
                List<Kho> khos = db.Khos.Where(x => x.IdSp == sps[i].Id && x.TrangThai == true).ToList();
                Gium gium = db.Gia.Where(x => x.IdSp == sps[i].Id && x.TrangThai == true).FirstOrDefault();
                SanPham sanPham = new SanPham(sps[i], anhs,gium,khos);
                sanPhams.Add(sanPham);
            }    
            return sanPhams;            
        }
        public SanPham GetById(int id)
        {
            Sp sp = db.Sps.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            List<AnhSp> anhs = db.AnhSps.Where(x=> x.IdSp==sp.Id && x.TrangThai == true).ToList();
            List<Kho> khos = db.Khos.Where(x => x.IdSp == sp.Id && x.TrangThai == true).ToList();
            Gium gium = db.Gia.Where(x => x.IdSp == sp.Id && x.TrangThai == true).FirstOrDefault();
            SanPham sanPham = new SanPham(sp, anhs,gium,khos);
            return sanPham;
        }
        public List<SanPham> GetByIdDong(int id)
        {
            List<SanPham> sanPhams = new List<SanPham>();
            List<Sp> sps = db.Sps.Where(x => x.TrangThai == true && x.IdDong==id).ToList();
            for (int i = 0; i < sps.Count; i++)
            {
                List<AnhSp> anhs = db.AnhSps.Where(x => x.IdSp == sps[i].Id && x.TrangThai == true).ToList();
                List<Kho> khos = db.Khos.Where(x => x.IdSp == sps[i].Id && x.TrangThai == true).ToList();
                Gium gium = db.Gia.Where(x => x.IdSp == sps[i].Id && x.TrangThai == true).FirstOrDefault();
                SanPham sanPham = new SanPham(sps[i], anhs, gium, khos);
                sanPhams.Add(sanPham);
            }
            return sanPhams;
        }
    }
}
