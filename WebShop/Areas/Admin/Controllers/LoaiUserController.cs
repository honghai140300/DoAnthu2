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
    public class LoaiUserController : Controller
    {
        private readonly DPContext _context;

        public LoaiUserController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiUser
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiUser.ToListAsync());
        }

        // GET: Admin/LoaiUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiUserModel = await _context.LoaiUser
                .FirstOrDefaultAsync(m => m.IDLoai == id);
            if (loaiUserModel == null)
            {
                return NotFound();
            }

            return View(loaiUserModel);
        }

        // GET: Admin/LoaiUser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDLoai,Name")] LoaiUserModel loaiUserModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiUserModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiUserModel);
        }

        // GET: Admin/LoaiUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiUserModel = await _context.LoaiUser.FindAsync(id);
            if (loaiUserModel == null)
            {
                return NotFound();
            }
            return View(loaiUserModel);
        }

        // POST: Admin/LoaiUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDLoai,Name")] LoaiUserModel loaiUserModel)
        {
            if (id != loaiUserModel.IDLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiUserModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiUserModelExists(loaiUserModel.IDLoai))
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
            return View(loaiUserModel);
        }

        // GET: Admin/LoaiUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiUserModel = await _context.LoaiUser
                .FirstOrDefaultAsync(m => m.IDLoai == id);
            if (loaiUserModel == null)
            {
                return NotFound();
            }

            return View(loaiUserModel);
        }

        // POST: Admin/LoaiUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiUserModel = await _context.LoaiUser.FindAsync(id);
            _context.LoaiUser.Remove(loaiUserModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiUserModelExists(int id)
        {
            return _context.LoaiUser.Any(e => e.IDLoai == id);
        }
    }
}
