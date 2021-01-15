using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Areas.Admin.Models
{
    public class LoaiUserModel
    {
        [Key]
        public int IDLoai { get; set; }
        public string Name { get; set; }

    }
}
