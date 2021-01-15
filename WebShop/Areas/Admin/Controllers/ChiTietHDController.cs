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
    public class ChiTietHDController : Controller
    {
        private readonly DPContext _context;

        public ChiTietHDController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/ChiTietHD
        public async Task<IActionResult> Index()
        {
            return View(await _context.CTHD.ToListAsync());
        }

        // GET: Admin/ChiTietHD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHDModel = await _context.CTHD
                .FirstOrDefaultAsync(m => m.idCTHD == id);
            if (chiTietHDModel == null)
            {
                return NotFound();
            }

            return View(chiTietHDModel);
        }

        // GET: Admin/ChiTietHD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChiTietHD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCTHD,idHD,IdSanPham,SoLuong,TongTien,TrangThai")] ChiTietHDModel chiTietHDModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHDModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chiTietHDModel);
        }

        // GET: Admin/ChiTietHD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHDModel = await _context.CTHD.FindAsync(id);
            if (chiTietHDModel == null)
            {
                return NotFound();
            }
            return View(chiTietHDModel);
        }

        // POST: Admin/ChiTietHD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCTHD,idHD,IdSanPham,SoLuong,TongTien,TrangThai")] ChiTietHDModel chiTietHDModel)
        {
            if (id != chiTietHDModel.idCTHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHDModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHDModelExists(chiTietHDModel.idCTHD))
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
            return View(chiTietHDModel);
        }

        // GET: Admin/ChiTietHD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHDModel = await _context.CTHD
                .FirstOrDefaultAsync(m => m.idCTHD == id);
            if (chiTietHDModel == null)
            {
                return NotFound();
            }

            return View(chiTietHDModel);
        }

        // POST: Admin/ChiTietHD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietHDModel = await _context.CTHD.FindAsync(id);
            _context.CTHD.Remove(chiTietHDModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHDModelExists(int id)
        {
            return _context.CTHD.Any(e => e.idCTHD == id);
        }
    }
}
