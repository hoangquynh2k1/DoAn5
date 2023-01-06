using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Admin_ElecShop.Entities;
using API_Admin_ElecShop.Models;

namespace API_Admin_ElecShop.DAO
{
    public class KhachHangDAO
    {
        lkshopContext db = new lkshopContext();
        public List<KhachHangModel> GetList()
        {
            List<KhachHangModel> khachhangs = new List<KhachHangModel>();
            List<KhachHang> khs = db.KhachHangs.Where(x => x.TrangThai == true).ToList();
            for (int i = 0; i < khs.Count; i++)
            {
                List<TaiKhoanKh> taiKhoans = db.TaiKhoanKhs.Where
                    (x => x.TrangThai == true && x.IdKh == khs[i].Id).ToList();
                List<DiaChi> diaChis = db.DiaChis.Where
                    (x => x.IdKh == khs[i].Id && x.TrangThai == true).ToList();
                KhachHangModel khach = new KhachHangModel(khs[i], taiKhoans, diaChis);
                khachhangs.Add(khach);
            }
            return khachhangs;
        }
        public KhachHangModel GetById(int id)
        {
            KhachHang khach = db.KhachHangs.Where(x => x.TrangThai == true && x.Id == id).FirstOrDefault();
            List<TaiKhoanKh> taiKhoans = db.TaiKhoanKhs.Where
                (x => x.IdKh == khach.Id && x.TrangThai == true).ToList();
            List<DiaChi> diaChis = db.DiaChis.Where(x => x.IdKh == khach.Id).ToList();
            KhachHangModel khachhang = new KhachHangModel(khach, taiKhoans, diaChis);
            return khachhang;
        }
        public TaiKhoanKh Login(string username, string password)
        {
            TaiKhoanKh tk = db.TaiKhoanKhs.Where(x => x.Username == username
            && x.Password == password).FirstOrDefault();
            return tk;
        }
        public bool Create(KhachHangModel h)
        {
            if (h != null)
            {
                KhachHang khachHang = new KhachHang();
                khachHang.HoTen = h.HoTen;
                khachHang.NamSinh = h.NamSinh;
                khachHang.Sdt = h.Sdt;
                khachHang.Email = h.Email;
                khachHang.GioiTinh = h.GioiTinh;
                khachHang.TrangThai = h.TrangThai;
                db.KhachHangs.Add(khachHang);
                for (int i = 0; i < h.diaChis.Count; i++)
                {
                    db.DiaChis.Add(h.diaChis[i]);
                }
                for (int i = 0; i < h.taiKhoans.Count; i++)
                {
                    db.TaiKhoanKhs.Add(h.taiKhoans[i]);
                }
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(KhachHangModel h)
        {
            if (h != null)
            {
                KhachHang khachHang = db.KhachHangs.Where
                    (x => x.TrangThai == true && x.Id == h.Id).FirstOrDefault();
                khachHang.HoTen = h.HoTen;
                khachHang.NamSinh = h.NamSinh;
                khachHang.Sdt = h.Sdt;
                khachHang.Email = h.Email;
                khachHang.GioiTinh = h.GioiTinh;
                khachHang.TrangThai = h.TrangThai;
                for (int i = 0; i < h.diaChis.Count; i++)
                {
                    DiaChi d = db.DiaChis.Where(x => x.Id == h.diaChis[i].Id).FirstOrDefault();
                    if (d != null)
                    {
                        d = h.diaChis[i];
                    }
                    else
                        db.DiaChis.Add(h.diaChis[i]);
                }
                for (int i = 0; i < h.taiKhoans.Count; i++)
                {
                    TaiKhoanKh d = db.TaiKhoanKhs.Where(x => x.Id == h.taiKhoans[i].Id).FirstOrDefault();
                    if (d != null)
                    {
                        d = h.taiKhoans[i];
                    }
                    else
                        db.TaiKhoanKhs.Add(h.taiKhoans[i]);
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
            KhachHang kh = db.KhachHangs.Where(x => x.Id == id && x.TrangThai == true).FirstOrDefault();
            List<DiaChi> list = db.DiaChis.Where
                (x => x.IdKh == kh.Id && x.TrangThai == true).ToList();
            List<TaiKhoanKh> list1 = db.TaiKhoanKhs.Where
                (x => x.IdKh == kh.Id && x.TrangThai == true).ToList();
            if (kh != null)
            {
                kh.TrangThai = false;
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].TrangThai = false;
                }
                for (int i = 0; i < list1.Count; i++)
                {
                    list1[i].TrangThai = false;
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
