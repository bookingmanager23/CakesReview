using CakesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CakesApi.Database
{
    public class CakesDbContext : DbContext
    {
        public DbSet<Cake> Cakes { get; set; }

        public CakesDbContext(DbContextOptions<CakesDbContext> options) : base(options)
        {
        }
    }
}
