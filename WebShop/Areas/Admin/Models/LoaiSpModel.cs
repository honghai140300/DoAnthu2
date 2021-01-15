using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Areas.Admin.Models
{
    public class LoaiSpModel
    {
        [Key]
        public int IdLoai { get; set; }
        [Display(Name = "Tên Loại Sản Phẩm")]
        public string TenLoai { get; set; }
    }
}
