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
    public class DanhMucController : Controller
    {
        private readonly DPContext _context;

        public DanhMucController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/DanhMuc
        public async Task<IActionResult> Index()
        {
            return View(await _context.DanhMuc.ToListAsync());
        }

        // GET: Admin/DanhMuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucModel = await _context.DanhMuc
                .FirstOrDefaultAsync(m => m.IdDanhMuc == id);
            if (danhMucModel == null)
            {
                return NotFound();
            }

            return View(danhMucModel);
        }

        // GET: Admin/DanhMuc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDanhMuc,Name")] DanhMucModel danhMucModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhMucModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhMucModel);
        }

        // GET: Admin/DanhMuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucModel = await _context.DanhMuc.FindAsync(id);
            if (danhMucModel == null)
            {
                return NotFound();
            }
            return View(danhMucModel);
        }

        // POST: Admin/DanhMuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDanhMuc,Name")] DanhMucModel danhMucModel)
        {
            if (id != danhMucModel.IdDanhMuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMucModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucModelExists(danhMucModel.IdDanhMuc))
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
            return View(danhMucModel);
        }

        // GET: Admin/DanhMuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucModel = await _context.DanhMuc
                .FirstOrDefaultAsync(m => m.IdDanhMuc == id);
            if (danhMucModel == null)
            {
                return NotFound();
            }

            return View(danhMucModel);
        }

        // POST: Admin/DanhMuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danhMucModel = await _context.DanhMuc.FindAsync(id);
            _context.DanhMuc.Remove(danhMucModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucModelExists(int id)
        {
            return _context.DanhMuc.Any(e => e.IdDanhMuc == id);
        }
    }
}
