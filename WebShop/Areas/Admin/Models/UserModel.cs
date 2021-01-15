using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Areas.Admin.Models
{
    public class UserModel
    {
        [Key]
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gmail { get; set; }
        public string AnhDaiDien { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        public int LichSuGD { get; set; }
        public int GioHang { get; set; }
        public int LoaiTK { get; set; }
        public string LienKetFB { get; set; }
    }
}
