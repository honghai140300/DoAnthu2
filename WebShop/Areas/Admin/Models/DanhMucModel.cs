using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Areas.Admin.Models
{
    public class DanhMucModel
    {
        [Key]
        public int IdDanhMuc { get; set; }
        [Display(Name ="Nhập Tên Danh Mục")]
        [Column(TypeName="nvarchar(100)")]
        public string Name { get; set; }
    }
}
