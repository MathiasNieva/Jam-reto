using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ArtistContext _context;

        public ArtistController(ArtistContext context)
        {
            _context = context;
        }

        // GET: api/Artist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistaDTO>>> GetArtistModel()
        {
          if (_context.Artistas == null)
          {
              return NotFound();
          }
            return await _context.Artistas
            .Select(x => ArtistaDTO.ArtistaToDTO(x))
            .ToListAsync();
        }

        // GET: api/Artist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistaDTO>> GetArtistModel(Guid id)
        {
          if (_context.Artistas == null)
          {
              return NotFound();
          }
            var artistModel = await _context.Artistas.FindAsync(id);

            if (artistModel == null)
            {
                return NotFound();
            }

            return ArtistaDTO.ArtistaToDTO(artistModel);
        }

        // PUT: api/Artist/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtistModel(Guid id, ArtistaDTO artistDTO)
        {
            ArtistModel artistModel = ArtistaDTO.DTOToArtista(artistDTO);
            if (id != artistModel.ArtistaId)
            {
                return BadRequest();
            }

            _context.Entry(artistModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistModelExists(id))
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

        // POST: api/Artist
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArtistaDTO>> PostArtistModel(ArtistaDTO artistDTO)
        {
          if (_context.Artistas == null)
          {
              return Problem("Entity set 'ArtistContext.ArtistModel'  is null.");
          }
          ArtistModel artistModel = ArtistaDTO.DTOToArtista(artistDTO);

            _context.Artistas.Add(artistModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtistModel", new { id = artistModel.ArtistaId }, artistModel);
        }

        // DELETE: api/Artist/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtistModel(Guid id)
        {
            if (_context.Artistas == null)
            {
                return NotFound();
            }
            var artistModel = await _context.Artistas.FindAsync(id);
            if (artistModel == null)
            {
                return NotFound();
            }

            _context.Artistas.Remove(artistModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistModelExists(Guid id)
        {
            return (_context.Artistas?.Any(e => e.ArtistaId == id)).GetValueOrDefault();
        }
    }
}
