using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
namespace WebShop.Areas.Admin.Data
{
    public class DPContext : DbContext
    {
        public DPContext(DbContextOptions<DPContext>options):base(options)
        {

        }
        public DbSet<UserModel> User { get; set; }
        public DbSet<LoaiUserModel> LoaiUser { get; set; }
        public DbSet<SanPhamModel> SanPham { get; set; }
        public DbSet<LoaiSpModel> LoaiSp { get; set; }
        public DbSet<HoaDonModel> HoaDon { get; set; }
        public DbSet<ChiTietHDModel> CTHD { get; set; }
        public DbSet<GioHangModel> GioGang { get; set; }
        public DbSet<DanhMucModel> DanhMuc { get; set; }
    }
}
