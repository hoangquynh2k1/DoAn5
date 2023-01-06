using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API_Elec_Shop.Models
{
    public partial class lkshopContext : DbContext
    {
        public lkshopContext()
        {
        }

        public lkshopContext(DbContextOptions<lkshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnhSp> AnhSps { get; set; }
        public virtual DbSet<CtGioHang> CtGioHangs { get; set; }
        public virtual DbSet<CtHoaDonBan> CtHoaDonBans { get; set; }
        public virtual DbSet<CtHoaDonNhap> CtHoaDonNhaps { get; set; }
        public virtual DbSet<DiaChi> DiaChis { get; set; }
        public virtual DbSet<DongSp> DongSps { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<Gium> Gia { get; set; }
        public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Kho> Khos { get; set; }
        public virtual DbSet<LoaiSp> LoaiSps { get; set; }
        public virtual DbSet<Ncc> Nccs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Sp> Sps { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TaiKhoanKh> TaiKhoanKhs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RGS773K;Database=lkshop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AnhSp>(entity =>
            {
                entity.ToTable("anh_sp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DuongDan)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("duong_dan");

                entity.Property(e => e.IdSp).HasColumnName("id_SP");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
            });

            modelBuilder.Entity<CtGioHang>(entity =>
            {
                entity.ToTable("ct_gio_hang");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gia).HasColumnName("gia");

                entity.Property(e => e.IdGioHang).HasColumnName("id_gio_hang");

                entity.Property(e => e.IdKho).HasColumnName("id_kho");

                entity.Property(e => e.IdSp).HasColumnName("id_Sp");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
            });

            modelBuilder.Entity<CtHoaDonBan>(entity =>
            {
                entity.ToTable("ct_hoa_don_ban");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gia).HasColumnName("gia");

                entity.Property(e => e.IdHoaDonBan).HasColumnName("id_hoa_don_ban");

                entity.Property(e => e.IdKho).HasColumnName("id_kho");

                entity.Property(e => e.IdSp).HasColumnName("id_SP");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
            });

            modelBuilder.Entity<CtHoaDonNhap>(entity =>
            {
                entity.ToTable("ct_hoa_don_nhap");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GiaNhap).HasColumnName("gia_Nhap");

                entity.Property(e => e.IdHoaDonNhap).HasColumnName("id_hoa_don_nhap");

                entity.Property(e => e.IdKho).HasColumnName("id_kho");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
            });

            modelBuilder.Entity<DiaChi>(entity =>
            {
                entity.ToTable("dia_chi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChiTiet)
                    .HasMaxLength(255)
                    .HasColumnName("chi_tiet");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(100)
                    .HasColumnName("ho_ten");

                entity.Property(e => e.Huyen)
                    .HasMaxLength(100)
                    .HasColumnName("huyen");

                entity.Property(e => e.IdKh).HasColumnName("id_KH");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("sdt");

                entity.Property(e => e.Tinh)
                    .HasMaxLength(100)
                    .HasColumnName("tinh");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");

                entity.Property(e => e.Xa)
                    .HasMaxLength(100)
                    .HasColumnName("xa");
            });

            modelBuilder.Entity<DongSp>(entity =>
            {
                entity.ToTable("dong_sp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HangSx)
                    .HasMaxLength(255)
                    .HasColumnName("hang_sx");

                entity.Property(e => e.IdLoai).HasColumnName("id_loai");

                entity.Property(e => e.NamSx).HasColumnName("nam_sx");

                entity.Property(e => e.TenDong)
                    .HasMaxLength(255)
                    .HasColumnName("ten_dong");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.ToTable("gio_hang");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdKh).HasColumnName("id_KH");

                entity.Property(e => e.NgayDat)
                    .HasColumnType("date")
                    .HasColumnName("ngay_Dat");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
            });

            modelBuilder.Entity<Gium>(entity =>
            {
                entity.ToTable("gia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GiaBan).HasColumnName("gia_ban");

                entity.Property(e => e.IdSp).HasColumnName("id_SP");

                entity.Property(e => e.NgayAd)
                    .HasColumnType("date")
                    .HasColumnName("ngay_AD");

                entity.Property(e => e.NgayKt)
                    .HasColumnType("date")
                    .HasColumnName("ngay_KT");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
            });

            modelBuilder.Entity<HoaDonBan>(entity =>
            {
                entity.ToTable("hoa_don_ban");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdDiaChi).HasColumnName("id_dia_chi");

                entity.Property(e => e.IdKh).HasColumnName("id_KH");

                entity.Property(e => e.NgayDat)
                    .HasColumnType("date")
                    .HasColumnName("ngay_dat");

                entity.Property(e => e.TinhTrangDh).HasColumnName("tinh_trang_dh");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
            });

            modelBuilder.Entity<HoaDonNhap>(entity =>
            {
                entity.ToTable("hoa_don_nhap");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdNcc).HasColumnName("id_ncc");

                entity.Property(e => e.IdNhanVien).HasColumnName("id_nhan_vien");

                entity.Property(e => e.NgayNhap)
                    .HasColumnType("date")
                    .HasColumnName("ngay_nhap");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.ToTable("khach_hang");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.GioiTinh).HasColumnName("gioi_Tinh");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(255)
                    .HasColumnName("ho_Ten");

                entity.Property(e => e.NamSinh).HasColumnName("nam_Sinh");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sdt");

                entity.Property(e => e.TrangThai).HasColumnName("trang_Thai");
            });

            modelBuilder.Entity<Kho>(entity =>
            {
                entity.ToTable("kho");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdSp).HasColumnName("id_SP");

                entity.Property(e => e.TinhTrang).HasColumnName("tinh_Trang");

                entity.Property(e => e.TrangThai).HasColumnName("trang_Thai");
            });

            modelBuilder.Entity<LoaiSp>(entity =>
            {
                entity.ToTable("loai_sp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MoTa)
                    .HasColumnType("ntext")
                    .HasColumnName("mo_ta");

                entity.Property(e => e.TenLoai)
                    .HasMaxLength(255)
                    .HasColumnName("ten_loai");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
            });

            modelBuilder.Entity<Ncc>(entity =>
            {
                entity.ToTable("ncc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DiaChi)
                    .HasColumnType("ntext")
                    .HasColumnName("dia_Chi");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("sdt");

                entity.Property(e => e.Stk)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("stk");

                entity.Property(e => e.TenNcc)
                    .HasMaxLength(255)
                    .HasColumnName("ten_ncc");

                entity.Property(e => e.TenNh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ten_NH");

                entity.Property(e => e.TrangThai).HasColumnName("trang_Thai");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.ToTable("nhan_Vien");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cccd");

                entity.Property(e => e.ChucVu)
                    .HasMaxLength(50)
                    .HasColumnName("chuc_Vu");

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(2000)
                    .HasColumnName("dia_Chi");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.GioiTinh).HasColumnName("gioi_Tinh");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(255)
                    .HasColumnName("ho_Ten");

                entity.Property(e => e.NgaySinh)
                    .HasColumnType("date")
                    .HasColumnName("ngay_Sinh");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("sdt");

                entity.Property(e => e.Stk)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("stk");

                entity.Property(e => e.TenNh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ten_NH");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
            });

            modelBuilder.Entity<Sp>(entity =>
            {
                entity.ToTable("sp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdDong).HasColumnName("id_dong");

                entity.Property(e => e.MoTa)
                    .HasColumnType("ntext")
                    .HasColumnName("mo_ta");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(255)
                    .HasColumnName("ten_SP");

                entity.Property(e => e.ThongSoKt)
                    .HasColumnType("ntext")
                    .HasColumnName("thong_so_KT");

                entity.Property(e => e.TrangThai).HasColumnName("trang_Thai");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.ToTable("tai_Khoan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdNv).HasColumnName("id_NV");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TaiKhoanKh>(entity =>
            {
                entity.ToTable("tai_KhoanKH");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdKh).HasColumnName("id_KH");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.TrangThai).HasColumnName("trang_thai");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdKhNavigation)
                    .WithMany(p => p.TaiKhoanKhs)
                    .HasForeignKey(d => d.IdKh)
                    .HasConstraintName("fk_tai_khoan_khachhang");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
