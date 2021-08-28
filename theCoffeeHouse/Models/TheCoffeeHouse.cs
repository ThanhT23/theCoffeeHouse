using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace theCoffeeHouse.Models
{
    public partial class TheCoffeeHouse : DbContext
    {
        public TheCoffeeHouse()
            : base("name=TheCoffeeHouse1")
        {
        }

        public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhoHang> KhoHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<PhanHoi> PhanHois { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThongTinAdmin> ThongTinAdmins { get; set; }
        public virtual DbSet<ThongTinKhachHang> ThongTinKhachHangs { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhoHang>()
                .HasOptional(e => e.SanPham)
                .WithRequired(e => e.KhoHang)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiSanPham>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.LoaiSanPham)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.tenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.matKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.ThongTinAdmins)
                .WithOptional(e => e.TaiKhoan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.ThongTinKhachHangs)
                .WithOptional(e => e.TaiKhoan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThongTinAdmin>()
                .Property(e => e.tenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinAdmin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinKhachHang>()
                .Property(e => e.tenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinKhachHang>()
                .Property(e => e.soDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinKhachHang>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}
