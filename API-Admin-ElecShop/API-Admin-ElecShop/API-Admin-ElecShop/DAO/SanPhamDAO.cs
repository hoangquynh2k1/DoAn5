using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Entities;
using API_Admin_ElecShop.Models;

namespace API_Admin_ElecShop.DAO
{
    public class SanPhamDAO
    {
        lkshopContext db = new lkshopContext();
        public List<SanPhamModel> Getlist()
        {
            List<SanPhamModel> SanPhamModels = new List<SanPhamModel>();
            List<Sp> sps = db.Sps.Where(x => x.TrangThai == true).ToList();
            for (int i = 0; i < sps.Count; i++)
            {
                List<AnhSp> anhs = db.AnhSps.Where(x => x.IdSp == sps[i].Id && x.TrangThai == true).ToList();
                List<Kho> khos = db.Khos.Where(x => x.IdSp == sps[i].Id && x.TrangThai == true).ToList();
                Gium gium = db.Gia.Where(x => x.IdSp == sps[i].Id && x.TrangThai == true).FirstOrDefault();
                SanPhamModel SanPhamModel = new SanPhamModel(sps[i], anhs, gium, khos);
                SanPhamModels.Add(SanPhamModel);
            }
            return SanPhamModels;
        }
        public SanPhamModel GetById(int id)
        {
            Sp sp = db.Sps.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            List<AnhSp> anhs = db.AnhSps.Where(x => x.IdSp == sp.Id && x.TrangThai == true).ToList();
            List<Kho> khos = db.Khos.Where(x => x.IdSp == sp.Id && x.TrangThai == true).ToList();
            Gium gium = db.Gia.Where(x => x.IdSp == sp.Id && x.TrangThai == true).FirstOrDefault();
            SanPhamModel SanPhamModel = new SanPhamModel(sp, anhs, gium, khos);
            return SanPhamModel;
        }
        public List<SanPhamModel> GetByIdDong(int id)
        {
            List<SanPhamModel> SanPhamModels = new List<SanPhamModel>();
            List<Sp> sps = db.Sps.Where(x => x.TrangThai == true && x.IdDong == id).ToList();
            for (int i = 0; i < sps.Count; i++)
            {
                List<AnhSp> anhs = db.AnhSps.Where(x => x.IdSp == sps[i].Id && x.TrangThai == true).ToList();
                List<Kho> khos = db.Khos.Where(x => x.IdSp == sps[i].Id && x.TrangThai == true).ToList();
                Gium gium = db.Gia.Where(x => x.IdSp == sps[i].Id && x.TrangThai == true).FirstOrDefault();
                SanPhamModel SanPhamModel = new SanPhamModel(sps[i], anhs, gium, khos);
                SanPhamModels.Add(SanPhamModel);
            }
            return SanPhamModels;
        }
        public bool Create(SanPhamModel o)
        {
            if (o != null)
            {
                Sp obj = new Sp();
                obj.IdDong = o.IdDong;
                obj.TenSp = o.TenSp;
                obj.MoTa = o.MoTa;
                obj.ThongSoKt = o.ThongSoKt;
                obj.TrangThai = o.TrangThai;
                db.Sps.Add(obj);
                db.SaveChanges();
                Gium g = new Gium();
                Sp sp = db.Sps.Where(x => x.IdDong == obj.IdDong && x.TenSp == obj.TenSp).FirstOrDefault();
                g.IdSp = sp.Id;
                g.GiaBan = o.gia;
                g.NgayAd = DateTime.Now;
                g.TrangThai = true;
                db.Gia.Add(g);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Update(SanPhamModel o)
        {
            if (o != null)
            {
                Sp obj = db.Sps.Where
                    (x => x.Id == o.Id && x.TrangThai == true).FirstOrDefault();
                obj.IdDong = o.IdDong;
                obj.TenSp = o.TenSp;
                obj.TrangThai = o.TrangThai;
                List<AnhSp> anhs = db.AnhSps.Where(x => x.IdSp == o.Id && x.TrangThai == true).ToList();
                Gium gia = db.Gia.Where(x => x.IdSp == o.Id && x.GiaBan==x.GiaBan && x.TrangThai == true).FirstOrDefault();
                if (anhs.Count < o.anhs.Count)
                {
                    for (int i = 0; i < o.anhs.Count; i++)
                    {
                        bool ch = false;
                        for (int j = 0; j < anhs.Count; j++)
                        {
                            if (o.anhs[i].Id == anhs[j].Id)
                            {
                                anhs[j] = o.anhs[i];
                                ch = true;
                            }
                        }
                        if (!ch)
                            db.AnhSps.Add(o.anhs[i]);
                    }
                }
                else if(anhs.Count == o.anhs.Count)
                {
                    for (int i = 0; i < anhs.Count; i++)
                    {
                        anhs[i] = o.anhs[i];
                    }    
                }    
                else
                {
                    for (int i = 0; i < anhs.Count; i++)
                    {
                        bool ch = false;
                        for (int j = 0; j < o.anhs.Count; j++)
                        {
                            if (o.anhs[j].Id == anhs[i].Id)
                            {
                                anhs[i] = o.anhs[j];
                                ch = true;
                                break;
                            }
                        }
                        if (!ch)
                        {
                            anhs[i].TrangThai = false;
                        }
                    }
                }
                if(gia==null)
                {
                    Gium giacu = db.Gia.Where(x => x.IdSp == o.Id && x.TrangThai == true).FirstOrDefault();
                    giacu.NgayKt = DateTime.Now;
                    giacu.TrangThai = false;
                    Gium giamoi = new Gium();
                    giamoi.GiaBan = o.gia;
                    giamoi.IdSp = o.Id;
                    giamoi.NgayAd = DateTime.Now;
                    giamoi.NgayKt = null;
                    giamoi.TrangThai = true;
                    db.Gia.Add(giamoi);
                }
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Delete(int id)
        {
            Sp obj = db.Sps.Where
                (x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            if (obj != null)
            {
                List<AnhSp> list = db.AnhSps.Where
                (x => x.IdSp == obj.Id && x.TrangThai == true).ToList();
                List<Kho> khos = db.Khos.Where
                (x => x.IdSp == obj.Id && x.TrangThai == true).ToList();
                Gium giacu = db.Gia.Where(x => x.IdSp == obj.Id && x.TrangThai == true).FirstOrDefault();
                giacu.TrangThai = false;
                obj.TrangThai = false;
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].TrangThai = false;
                }
                for (int i = 0; i < khos.Count; i++)
                {
                    khos[i].TrangThai = false;
                }
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
