using Microsoft.EntityFrameworkCore;
using proiectPIU.Models;


namespace proiectPIU.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Item> Items { get; set; }
    }
}
