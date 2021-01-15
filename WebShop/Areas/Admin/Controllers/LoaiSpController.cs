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
    public class LoaiSpController : Controller
    {
        private readonly DPContext _context;

        public LoaiSpController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiSp
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiSp.ToListAsync());
        }

        // GET: Admin/LoaiSp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSpModel = await _context.LoaiSp
                .FirstOrDefaultAsync(m => m.IdLoai == id);
            if (loaiSpModel == null)
            {
                return NotFound();
            }

            return View(loaiSpModel);
        }

        // GET: Admin/LoaiSp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoai,TenLoai")] LoaiSpModel loaiSpModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiSpModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiSpModel);
        }

        // GET: Admin/LoaiSp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSpModel = await _context.LoaiSp.FindAsync(id);
            if (loaiSpModel == null)
            {
                return NotFound();
            }
            return View(loaiSpModel);
        }

        // POST: Admin/LoaiSp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoai,TenLoai")] LoaiSpModel loaiSpModel)
        {
            if (id != loaiSpModel.IdLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiSpModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSpModelExists(loaiSpModel.IdLoai))
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
            return View(loaiSpModel);
        }

        // GET: Admin/LoaiSp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSpModel = await _context.LoaiSp
                .FirstOrDefaultAsync(m => m.IdLoai == id);
            if (loaiSpModel == null)
            {
                return NotFound();
            }

            return View(loaiSpModel);
        }

        // POST: Admin/LoaiSp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiSpModel = await _context.LoaiSp.FindAsync(id);
            _context.LoaiSp.Remove(loaiSpModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiSpModelExists(int id)
        {
            return _context.LoaiSp.Any(e => e.IdLoai == id);
        }
    }
}
