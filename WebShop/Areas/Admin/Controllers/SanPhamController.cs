using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShop.Areas.Admin.Data;
using WebShop.Areas.Admin.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly DPContext _context;

        public SanPhamController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/SanPham
        public async Task<IActionResult> Index(string searchString)
        {
            var sanpham = from m in _context.SanPham
                       select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                sanpham = sanpham.Where(s => s.Name.Contains(searchString));
            }

            return View(await sanpham.ToListAsync());
        }

        // GET: Admin/SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPham
                .FirstOrDefaultAsync(m => m.IdSanPham == id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return View(sanPhamModel);
        }

        // GET: Admin/SanPham/Create
        public IActionResult Create()
        {
            ViewBag.ListSp = _context.LoaiSp.ToList();
            ViewBag.ListDanhMuc = _context.DanhMuc.ToList();
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSanPham,Name,LoaiSP,DanhMuc,GiaNhap,GiaBan,soluong,HinhAnh,ThuongHieu,XuatXu,ChatLieu,SKU,MoTa,KhuyenMai,soluongDaBan,Ngaynhap,TrangThai")] SanPhamModel sanPhamModel, IFormFile ful)
        {
            if (ModelState.IsValid)
            {
              
                _context.Add(sanPhamModel);
                ViewBag.ListSp = _context.LoaiSp.ToList();
                await _context.SaveChangesAsync();
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/img/Pro",
                   sanPhamModel.IdSanPham + "." + ful.FileName.Split(".")
                    [ful.FileName.Split(".").Length - 1]);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
               sanPhamModel.HinhAnh=sanPhamModel.IdSanPham + "." + ful.FileName.Split(".")
                     [ful.FileName.Split(".").Length - 1];
                _context.Update(sanPhamModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanPhamModel);
        }

        // GET: Admin/SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ListSp = _context.LoaiSp.ToList();
            ViewBag.ListDanhMuc = _context.DanhMuc.ToList();
            var sanPhamModel = await _context.SanPham.FindAsync(id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }
            return View(sanPhamModel);
        }

        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSanPham,Name,LoaiSP,DanhMuc,GiaNhap,GiaBan,soluong,HinhAnh,ThuongHieu,XuatXu,ChatLieu,SKU,MoTa,KhuyenMai,soluongDaBan,Ngaynhap,TrangThai")] SanPhamModel sanPhamModel, IFormFile ful)
        {
            if (id != sanPhamModel.IdSanPham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPhamModel);
                    ViewBag.ListSp = _context.LoaiSp.ToList();
                    ViewBag.ListDanhMuc = _context.DanhMuc.ToList();
                    await _context.SaveChangesAsync();
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/img/Pro",
                       sanPhamModel.IdSanPham + "." + ful.FileName.Split(".")
                        [ful.FileName.Split(".").Length - 1]);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await ful.CopyToAsync(stream);
                    }
                    sanPhamModel.HinhAnh = sanPhamModel.IdSanPham + "." + ful.FileName.Split(".")
                          [ful.FileName.Split(".").Length - 1];
                    _context.Update(sanPhamModel);
                    await _context.SaveChangesAsync();
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamModelExists(sanPhamModel.IdSanPham))
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
            return View(sanPhamModel);
        }

        // GET: Admin/SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPham
                .FirstOrDefaultAsync(m => m.IdSanPham == id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return View(sanPhamModel);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPhamModel = await _context.SanPham.FindAsync(id);
            _context.SanPham.Remove(sanPhamModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamModelExists(int id)
        {
            return _context.SanPham.Any(e => e.IdSanPham == id);
        }
    }
}
