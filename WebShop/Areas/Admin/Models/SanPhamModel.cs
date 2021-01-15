using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Areas.Admin.Models
{
    public class SanPhamModel
    {
        [Key]
        public int IdSanPham { get; set; }
        public string Name { get; set; }
        public int LoaiSP { get; set;  }
        public int DanhMuc { get; set; }
        public int GiaNhap { get; set; }
        public int GiaBan { get; set; }
        public int soluong { get; set; }
        public string HinhAnh { get; set; }
        public string ThuongHieu { get; set; }
        public string XuatXu { get; set; }
        public string ChatLieu { get; set; }
        public string SKU { get; set; }
        public string MoTa { get; set; }
        public int KhuyenMai { get; set; }
        public int soluongDaBan { get; set; }
        public string Ngaynhap { get; set; }
        public bool TrangThai { get; set; }


    }
}
