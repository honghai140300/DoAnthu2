using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Areas.Admin.Models
{
    public class GioHangModel
    {
       [Key]
       public int IdKhach { get; set; }
        public int idSanPham { get; set; }
        public int Soluong { get; set; }
        public float TongTien { get; set; }
    }
}
