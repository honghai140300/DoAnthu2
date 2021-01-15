using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShop.Areas.Admin.Data;
using WebShop.Areas.Admin.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoaDonController : Controller
    {
        private readonly DPContext _context;

        public HoaDonController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/HoaDon
        public async Task<IActionResult> Index(string searchString)
        {
            var hoadon = from m in _context.HoaDon
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                hoadon = hoadon.Where(s => s.NguoiLap.Contains(searchString));
            }

            return View(await hoadon.ToListAsync());
        }

        // GET: Admin/HoaDon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonModel = await _context.HoaDon
                .FirstOrDefaultAsync(m => m.IdHoaDon == id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }

            return View(hoaDonModel);
        }

        // GET: Admin/HoaDon/Create
        public IActionResult Create()
        {
            ViewBag.ListHoaDon = _context.User.ToList();
            return View();
        }

        // POST: Admin/HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHoaDon,IdUser,NguoiLap,TongTien,NgayLap,TrangThai")] HoaDonModel hoaDonModel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ListHoaDon = _context.User.ToList();
                _context.Add(hoaDonModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(hoaDonModel);
        }

        // GET: Admin/HoaDon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ListHoaDon = _context.User.ToList();
            var hoaDonModel = await _context.HoaDon.FindAsync(id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }
            return View(hoaDonModel);
        }

        // POST: Admin/HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHoaDon,IdUser,NguoiLap,TongTien,NgayLap,TrangThai")] HoaDonModel hoaDonModel)
        {
            if (id != hoaDonModel.IdHoaDon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDonModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonModelExists(hoaDonModel.IdHoaDon))
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
            return View(hoaDonModel);
        }

        // GET: Admin/HoaDon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonModel = await _context.HoaDon
                .FirstOrDefaultAsync(m => m.IdHoaDon == id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }

            return View(hoaDonModel);
        }

        // POST: Admin/HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDonModel = await _context.HoaDon.FindAsync(id);
            _context.HoaDon.Remove(hoaDonModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonModelExists(int id)
        {
            return _context.HoaDon.Any(e => e.IdHoaDon == id);
        }
    }
}
