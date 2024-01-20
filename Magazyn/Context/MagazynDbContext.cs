using Magazyn.Models;
using Microsoft.EntityFrameworkCore;

namespace Magazyn.Context
{
    public class MagazynDbContext : DbContext
    {
        public MagazynDbContext(DbContextOptions<MagazynDbContext>contextOptions)
            : base(contextOptions)
        {

        }

        public DbSet<Item> Items { get; set; }
    }
}
