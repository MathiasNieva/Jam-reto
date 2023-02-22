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
    public class DiscoController : ControllerBase
    {
        private readonly ArtistContext _context;

        public DiscoController(ArtistContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscoDTO>>> GetDisco()
        {
          if (_context.Discos == null)
          {
              return NotFound();
          }
            return await _context.Discos
            .Select(x => DiscoDTO.DiscoToDTO(x))
            .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiscoDTO>> GetDisco(Guid id)
        {
          if (_context.Discos == null)
          {
              return NotFound();
          }
            var discoModel = await _context.Discos.FindAsync(id);

            if (discoModel == null)
            {
                return NotFound();
            }

            return DiscoDTO.DiscoToDTO(discoModel);
        }

        [HttpGet("artistDisco/{id}")]
        public async Task<ActionResult<List<ArtistaDTO>>> GetArtistsOfDisco(Guid id)
        {
          if (_context.Discos == null)
          {
              return NotFound();
          }

          // find all artist with disco id
            var artistDiscoModels = await _context.ArtistaDisco
                                    .Where(ad => ad.DiscoId == id)
                                    .ToListAsync();


            if (artistDiscoModels == null)
            {
                return NotFound();
            }

            var artistIds = new List<Guid>();
            foreach (var artistDiscoModel in artistDiscoModels)
            {
                artistIds.Add(artistDiscoModel.ArtistaId);
            }

            // Get the artists info

            var artistNames = new List<ArtistaDTO>();
            foreach (var artistId in artistIds)
            {
                var artist = await _context.Artistas.FindAsync(artistId);
                
                artistNames.Add(ArtistaDTO.ArtistaToDTO(artist));
            }

            return artistNames;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisco(Guid id, DiscoDTO discoDTO)
        {
            DiscoModel discoModel = DiscoDTO.DTOToDisco(discoDTO);
            if (id != discoModel.DiscoId)
            {
                return BadRequest();
            }

            _context.Entry(discoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscoModelExists(id))
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

        [HttpPost]
        public async Task<ActionResult> PostDisco(ArtistaDiscoRequest request)
        {
            if (_context.Artistas == null)
            {
                return NotFound();
            }
            // Check if all artists with the given IDs exist
            foreach (var artistId in request.ArtistIds)
            {
                if (!await _context.Artistas.AnyAsync(a => a.ArtistaId == artistId))
                {
                    return NotFound($"Artist with ID {artistId} not found.");
                }
            }

            // Create new Disco object and add them to the database
            if (_context.Discos == null)
            {
                return Problem("Entity set 'DiscoContext.DiscoModel'  is null.");
            }
            request.DiscoDTO.DiscoId = Guid.NewGuid();
            DiscoModel discoModel = DiscoDTO.DTOToDisco(request.DiscoDTO);

            _context.Discos.Add(discoModel);

            // Create new ArtistaDisco objects and add them to the database
            foreach (var artistId in request.ArtistIds)
            {
                ArtistaDiscoModel artistaDisco = new ArtistaDiscoModel
                {
                    ArtistaId = artistId,
                    DiscoId = discoModel.DiscoId
                };
                _context.ArtistaDisco.Add(artistaDisco);
            }
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscoModel(Guid id)
        {
            if (_context.Discos == null)
            {
                return NotFound();
            }
            var discoModel = await _context.Discos.FindAsync(id);
            if (discoModel == null)
            {
                return NotFound();
            }

            _context.Discos.Remove(discoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiscoModelExists(Guid id)
        {
            return (_context.Discos?.Any(e => e.DiscoId == id)).GetValueOrDefault();
        }
    }
}
