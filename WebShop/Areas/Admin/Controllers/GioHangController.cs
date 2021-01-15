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
    public class GioHangController : Controller
    {
        private readonly DPContext _context;

        public GioHangController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/GioHang
        public async Task<IActionResult> Index()
        {
            return View(await _context.GioGang.ToListAsync());
        }

        // GET: Admin/GioHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gioHangModel = await _context.GioGang
                .FirstOrDefaultAsync(m => m.IdKhach == id);
            if (gioHangModel == null)
            {
                return NotFound();
            }

            return View(gioHangModel);
        }

        // GET: Admin/GioHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/GioHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKhach,idSanPham,Soluong,TongTien")] GioHangModel gioHangModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gioHangModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gioHangModel);
        }

        // GET: Admin/GioHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gioHangModel = await _context.GioGang.FindAsync(id);
            if (gioHangModel == null)
            {
                return NotFound();
            }
            return View(gioHangModel);
        }

        // POST: Admin/GioHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKhach,idSanPham,Soluong,TongTien")] GioHangModel gioHangModel)
        {
            if (id != gioHangModel.IdKhach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gioHangModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GioHangModelExists(gioHangModel.IdKhach))
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
            return View(gioHangModel);
        }

        // GET: Admin/GioHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gioHangModel = await _context.GioGang
                .FirstOrDefaultAsync(m => m.IdKhach == id);
            if (gioHangModel == null)
            {
                return NotFound();
            }

            return View(gioHangModel);
        }

        // POST: Admin/GioHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gioHangModel = await _context.GioGang.FindAsync(id);
            _context.GioGang.Remove(gioHangModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GioHangModelExists(int id)
        {
            return _context.GioGang.Any(e => e.IdKhach == id);
        }
    }
}
