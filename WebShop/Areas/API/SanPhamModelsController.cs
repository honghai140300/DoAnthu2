using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Areas.Admin.Data;
using WebShop.Areas.Admin.Models;

namespace WebShop.Areas.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamModelsController : ControllerBase
    {
        private readonly DPContext _context;

        public SanPhamModelsController(DPContext context)
        {
            _context = context;
        }

        // GET: api/SanPhamModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamModel>>> GetSanPham()
        {
            return await _context.SanPham.ToListAsync();
        }

        // GET: api/SanPhamModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPhamModel>> GetSanPhamModel(int id)
        {
            var sanPhamModel = await _context.SanPham.FindAsync(id);

            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return sanPhamModel;
        }

        // PUT: api/SanPhamModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPhamModel(int id, SanPhamModel sanPhamModel)
        {
            if (id != sanPhamModel.IdSanPham)
            {
                return BadRequest();
            }

            _context.Entry(sanPhamModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SanPhamModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SanPhamModel>> PostSanPhamModel(SanPhamModel sanPhamModel)
        {
            _context.SanPham.Add(sanPhamModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSanPhamModel", new { id = sanPhamModel.IdSanPham }, sanPhamModel);
        }

        // DELETE: api/SanPhamModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPhamModel(int id)
        {
            var sanPhamModel = await _context.SanPham.FindAsync(id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            _context.SanPham.Remove(sanPhamModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SanPhamModelExists(int id)
        {
            return _context.SanPham.Any(e => e.IdSanPham == id);
        }
    }
}
