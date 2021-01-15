using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Areas.Admin.Models
{
    public class ChiTietHDModel
    {
        [Key]
        public int idCTHD { get; set; }
        public int idHD { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public float TongTien { get; set; }
        public bool TrangThai { get; set; }
    }
}
