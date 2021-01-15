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
    public class GioHangModelsController : ControllerBase
    {
        private readonly DPContext _context;

        public GioHangModelsController(DPContext context)
        {
            _context = context;
        }

        // GET: api/GioHangModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GioHangModel>>> GetGioGang()
        {
            return await _context.GioGang.ToListAsync();
        }

        // GET: api/GioHangModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GioHangModel>> GetGioHangModel(int id)
        {
            var gioHangModel = await _context.GioGang.FindAsync(id);

            if (gioHangModel == null)
            {
                return NotFound();
            }

            return gioHangModel;
        }

        // PUT: api/GioHangModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGioHangModel(int id, GioHangModel gioHangModel)
        {
            if (id != gioHangModel.IdKhach)
            {
                return BadRequest();
            }

            _context.Entry(gioHangModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GioHangModelExists(id))
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

        // POST: api/GioHangModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GioHangModel>> PostGioHangModel(GioHangModel gioHangModel)
        {
            _context.GioGang.Add(gioHangModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGioHangModel", new { id = gioHangModel.IdKhach }, gioHangModel);
        }

        // DELETE: api/GioHangModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGioHangModel(int id)
        {
            var gioHangModel = await _context.GioGang.FindAsync(id);
            if (gioHangModel == null)
            {
                return NotFound();
            }

            _context.GioGang.Remove(gioHangModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GioHangModelExists(int id)
        {
            return _context.GioGang.Any(e => e.IdKhach == id);
        }
    }
}
