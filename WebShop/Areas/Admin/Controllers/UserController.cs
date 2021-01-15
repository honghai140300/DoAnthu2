using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebShop.Areas.Admin.Data;
using WebShop.Areas.Admin.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly DPContext _context;

        public UserController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Login
        public async Task<IActionResult> LoginAdmin([Bind("UserName,PassWord")] UserModel nguoidung)
        {
            var r = _context.User.Where(m => (m.UserName == nguoidung.UserName && m.PassWord == nguoidung.PassWord)).ToList();

            if (r.Count == 0)
                return View("Login");

            var str = JsonConvert.SerializeObject(nguoidung);
            HttpContext.Session.SetString("user", str);
            if (r[0].LoaiTK == 1)
            {
                var url = Url.RouteUrl(new { Controller = "User", Action = "Index", Area = "Admin" });
                return Redirect(url);
            }

            return View();
        }
        //Logout
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");

        }
        //Get Uer 
     /*   public void GetUser()
        {
            if(HttpContext.Session.GetString("user")!=null)
            {
                JObject us= JObject.Parse(HttpContext.Session.GetString("user"));
                UserModel USer = new UserModel();
                USer.PassWord = us.SelectToken("PassWord").ToString();
                USer.UserName = us.SelectToken("UserName").ToString();
                ViewBag.USer = _context.User.Where(m => m.UserName == USer.UserName).ToString();
            }
        }*/
        // GET: Admin/User
        public async Task<IActionResult> Index(string searchString)
        {
            var user = from m in _context.User
                       select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                user = user.Where(s => s.UserName.Contains(searchString));
            }
           
            return View(await user.ToListAsync());
        }



      

        // GET: Admin/User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.User
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: Admin/User/Create
        public IActionResult Create()
        {
            ViewBag.ListUser = _context.LoaiUser.ToList();
            return View();
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,UserName,PassWord,FirstName,LastName,Gmail,AnhDaiDien,Sdt,DiaChi,GioiTinh,NgaySinh,LichSuGD,GioHang,LoaiTK,LienKetFB")] UserModel userModel,IFormFile ful)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ListUser = _context.LoaiUser.ToList();
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/img/Pro",
                   userModel.IdUser + "." + ful.FileName.Split(".")
                    [ful.FileName.Split(".").Length - 1]);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
               userModel.AnhDaiDien = userModel.IdUser + "." + ful.FileName.Split(".")
                    [ful.FileName.Split(".").Length - 1];
                _context.Update(userModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: Admin/User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.User.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,UserName,PassWord,FirstName,LastName,Gmail,AnhDaiDien,Sdt,DiaChi,GioiTinh,NgaySinh,LichSuGD,GioHang,LoaiTK,LienKetFB")] UserModel userModel, IFormFile ful)
        {
            if (id != userModel.IdUser)
            {
                return NotFound();
            }
            ViewBag.ListUser = _context.LoaiUser.ToList();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(userModel);
                    
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/img/Pro",
                       userModel.IdUser + "." + ful.FileName.Split(".")
                        [ful.FileName.Split(".").Length - 1]);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await ful.CopyToAsync(stream);
                    }
                    userModel.AnhDaiDien = userModel.IdUser + "." + ful.FileName.Split(".")
                         [ful.FileName.Split(".").Length - 1];
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.IdUser))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: Admin/User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.User
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.User.FindAsync(id);
            _context.User.Remove(userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(int id)
        {
            return _context.User.Any(e => e.IdUser == id);
        }
    }
}
