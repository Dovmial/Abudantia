
using Abudantia.Models;
using Microsoft.EntityFrameworkCore;

namespace Abudantia.Data
{
    public class EfContext: DbContext
    {
        public EfContext(DbContextOptions options): base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
