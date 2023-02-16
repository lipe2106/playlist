using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moment4.Data;
using moment4.Models;

namespace moment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly PlaylistContext _context;

        public PlaylistController(PlaylistContext context)
        {
            _context = context;
        }

        // GET: api/Playlist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylist()
        {
          if (_context.Playlist == null)
          {
              return NotFound("Det finns för tillfället inga låtar i spellistan");
          }
            return await _context.Playlist.ToListAsync();
        }

        // GET: api/Playlist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
        {
          if (_context.Playlist == null)
          {
              return NotFound("Spellistan går inte att hitta för tillfället");
          }
            var playlist = await _context.Playlist.FindAsync(id);

            if (playlist == null)
            {
                return NotFound("Låten du sökte efter finns inte i spellistan");
            }

            return playlist;
        }

        // PUT: api/Playlist/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return BadRequest("Det gick inte att uppdatera låt. Har du glömt skicka med id?");
            }

            _context.Entry(playlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistExists(id))
                {
                    return NotFound("Låten du vill uppdatera finns inte i spellistan");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Playlist
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
          if (_context.Playlist == null)
          {
              return Problem("Entity set 'PlaylistContext.Playlist'  is null.");
          }
            _context.Playlist.Add(playlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaylist", new { id = playlist.Id }, playlist);
        }

        // DELETE: api/Playlist/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            if (_context.Playlist == null)
            {
                return NotFound("Spellistan kunde inte hittas för tillfället");
            }
            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist == null)
            {
                return NotFound("Låten du vill radera finns inte i spellistan");
            }

            _context.Playlist.Remove(playlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaylistExists(int id)
        {
            return (_context.Playlist?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
