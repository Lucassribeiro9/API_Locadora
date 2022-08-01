using API_Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Locadora.Data
{
    public class LocadoraDbContext : DbContext
    {
        public LocadoraDbContext(DbContextOptions<LocadoraDbContext> options) : base(options)
        {

        }
        public DbSet<Filme> Filmes { get; set; }
    }
}
