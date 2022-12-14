using System;
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

        

        [HttpGet("Busca por genero")]
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilmeGenero(string genero)
        {
            if (_context.Filmes == null)
            {
                return NotFound();
            }
            var filme = await _context.Filmes.Where(x => x.Genero.Equals(genero)).ToListAsync();
            /* caso o acesso seja feito pela memória, coloque a variável abaixo
              var filme = await _context.Filmes.Where(x => x.Genero.Equals(genero)).AsNoTracking().ToListAsync();
            */
            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        // PUT: api/Filme/5
        [HttpPut("Atualizar")]
        public async Task<IActionResult> PutFilme(int id, Filme filme)
        {
            if (id != filme.Id)
            {

                return Problem("O filme já existe! Faça uma alteração diferente.");
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
        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            if (_context.Filmes == null)
            {
                return Problem("Erro ao adicionar filme!");
            }
            if (FilmeExistsName(filme.Nome))
            {
                return Problem("Erro: Já existe um filme com este nome!");
            }
            if (ModelState.IsValid)
            {

                _context.Filmes.Add(filme);
                await _context.SaveChangesAsync();
                return filme;
                // return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/Filme/5
        [HttpDelete("Deletar por ID")]
        public async Task<IActionResult> DeleteFilme(int id)
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

        private bool FilmeExists(int id)
        {
            return (_context.Filmes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private bool FilmeExistsName(string nome)
        {
            return (_context.Filmes?.Any(e => e.Nome == nome)).GetValueOrDefault();
        }
    }
}
