using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Areas.Admin.Models
{
    public class HoaDonModel
    {
        [Key]
        public int IdHoaDon { get; set; }
        [Display(Name ="Tên khách hàng:")]
        public int IdUser { get; set; }
        public string NguoiLap { get; set; }
        public float TongTien { get; set; }
        public string NgayLap { get; set; }
        public bool TrangThai { get; set; }
    }
}
