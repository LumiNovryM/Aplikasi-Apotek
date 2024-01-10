using Aplikasi_Apotek.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aplikasi_Apotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangController : ControllerBase
    {
        private readonly ApotekContext _apotekContext;

        public BarangController(ApotekContext apotekContext)
        {
            _apotekContext = apotekContext;
        }

        // Get All User Data
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barang>>> GetBarang()
        {
            if (_apotekContext.Barang == null)
            {
                return NotFound();
            }
            return await _apotekContext.Barang.ToListAsync();
        }

        // Get User Data By Id
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Barang>> GetBarangById(int id)
        {
            if (_apotekContext.Barang == null)
            {
                return NotFound();
            }

            var barang = await _apotekContext.Barang.FindAsync(id);
            if (barang == null)
            {
                return NotFound();
            }
            return barang;
        }

        // Create New User
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Barang>> CreateNewBarang(Barang barang)
        {
            _apotekContext.Barang.Add(barang);
            await _apotekContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBarang), new { id = barang.Id_barang }, barang);
        }

        // Check
        private bool BarangAvailable(int id)
        {
            return (_apotekContext.Barang?.Any(x => x.Id_barang == id)).GetValueOrDefault();
        }

        // Edit Existing User
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> EditBarang(int id, Barang barang)
        {
            if (id != barang.Id_barang)
            {
                return BadRequest();
            }
            _apotekContext.Entry(barang).State = EntityState.Modified;
            try
            {
                await _apotekContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarangAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        // Delete User
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBarang(int id)
        {
            if (_apotekContext.Barang == null)
            {
                return NotFound();
            }
            var barang = await _apotekContext.Barang.FindAsync(id);
            if (barang == null)
            {
                return NotFound();
            }

            _apotekContext.Barang.Remove(barang);

            await _apotekContext.SaveChangesAsync();

            return Ok();
        }
    }
}
