﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Locadora.Data;
using API_Locadora.Models;

namespace API_Locadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly LocadoraDbContext _context;

        public FilmeController(LocadoraDbContext context)
        {
            _context = context;
        }

        // GET: api/Filme
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilmes()
        {
          if (_context.Filmes == null)
          {
              return NotFound();
          }
            return await _context.Filmes.ToListAsync();
        }

        // GET: api/Filme/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilme(string id)
        {
          if (_context.Filmes == null)
          {
              return NotFound();
          }
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        // PUT: api/Filme/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilme(string id, Filme filme)
        {
            if (id != filme.Nome)
            {
                return BadRequest();
            }

            _context.Entry(filme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(id))
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

        // POST: api/Filme
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
          if (_context.Filmes == null)
          {
              return Problem("Entity set 'LocadoraDbContext.Filmes'  is null.");
          }
            _context.Filmes.Add(filme);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FilmeExists(filme.Nome))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFilme", new { id = filme.Nome }, filme);
        }

        // DELETE: api/Filme/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilme(string id)
        {
            if (_context.Filmes == null)
            {
                return NotFound();
            }
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmeExists(string id)
        {
            return (_context.Filmes?.Any(e => e.Nome == id)).GetValueOrDefault();
        }
    }
}