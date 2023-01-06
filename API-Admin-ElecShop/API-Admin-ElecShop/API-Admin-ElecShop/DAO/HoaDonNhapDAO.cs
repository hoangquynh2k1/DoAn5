using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Entities;
using API_Admin_ElecShop.Models;

namespace API_Admin_ElecShop.DAO
{
    public class HoaDonNhapDAO
    {
        lkshopContext db = new lkshopContext();
        public List<HoaDonNhapModel> GetList()
        {
            List<HoaDonNhapModel> list = new List<HoaDonNhapModel>();
            List<HoaDonNhap> objs = db.HoaDonNhaps.Where(x => x.TrangThai == true).ToList();
            for (int i = 0; i < objs.Count; i++)
            {
                List<CtHoaDonNhap> anhs = db.CtHoaDonNhaps.Where(x => x.IdHoaDonNhap == objs[i].Id && x.TrangThai == true).ToList();
                List<Kho> khos = db.Khos.Where(x => x.IdSp == objs[i].Id && x.TrangThai == true).ToList();
                Gium gium = db.Gia.Where(x => x.IdSp == objs[i].Id && x.TrangThai == true).FirstOrDefault();
                HoaDonNhapModel obj = new HoaDonNhapModel(objs[i], anhs);
                list.Add(obj);
            }
            return list;
        }
        public HoaDonNhapModel GetById(int id)
        {
            HoaDonNhap result = db.HoaDonNhaps.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            List<CtHoaDonNhap> list = db.CtHoaDonNhaps.Where
                (x => x.IdHoaDonNhap == result.Id && x.TrangThai == true).ToList();
            HoaDonNhapModel hoaDon = new HoaDonNhapModel(result, list);
            return hoaDon;
        }
        //public HoaDonNhapModel GetByIdNCC(int id)
        //{
        //    HoaDonNhap result = db.HoaDonNhaps.Where(x => x.IdKh == id && x.TrangThai == true).OrderByDescending(x => x.Id).FirstOrDefault();
        //    List<CtHoaDonNhap> list = db.CtHoaDonNhaps.Where
        //        (x => x.IdHoaDonNhap == result.Id && x.TrangThai == true).ToList();
        //    HoaDonNhapModel hoaDon = new HoaDonNhapModel(result, list);
        //    return hoaDon;
        //}
        public bool Create(HoaDonNhapModel h)
        {
            if (h != null)
            {
                HoaDonNhap hoaDon = new HoaDonNhap();
                hoaDon.IdNcc = h.IdNcc;
                hoaDon.IdNhanVien = h.IdNhanVien;
                hoaDon.NgayNhap = h.NgayNhap;
                hoaDon.TrangThai = h.TrangThai;
                db.HoaDonNhaps.Add(hoaDon);
                if (h.CtHoaDonNhaps == null)
                {

                }
                else
                {
                    for (int i = 0; i < h.CtHoaDonNhaps.Count; i++)
                    {
                        db.CtHoaDonNhaps.Add(h.CtHoaDonNhaps[i]);
                    }
                }
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(HoaDonNhapModel h)
        {
            HoaDonNhap hoaDon = db.HoaDonNhaps.Where(x => x.Id == h.Id && x.TrangThai == true).FirstOrDefault();
            if (hoaDon != null)
            {
                hoaDon.Id = h.Id;
                hoaDon.IdNcc = h.IdNcc;
                hoaDon.IdNhanVien = h.IdNhanVien;
                hoaDon.NgayNhap = h.NgayNhap;
                hoaDon.TrangThai = h.TrangThai;
                for (int i = 0; i < h.CtHoaDonNhaps.Count; i++)
                {
                    CtHoaDonNhap ct = db.CtHoaDonNhaps.Where
                        (x => x.Id == h.CtHoaDonNhaps[i].Id && x.TrangThai == true).FirstOrDefault();
                    if (ct == null)
                        db.CtHoaDonNhaps.Add(h.CtHoaDonNhaps[i]);
                    else
                        ct = h.CtHoaDonNhaps[i];
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
            HoaDonNhap hoaDon = db.HoaDonNhaps.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            List<CtHoaDonNhap> list = db.CtHoaDonNhaps.Where
                (x => x.IdHoaDonNhap == hoaDon.Id && x.TrangThai == true).ToList();
            if (hoaDon != null)
            {
                hoaDon.TrangThai = false;
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].TrangThai = false;
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
