using Domain.Entities;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<House> House { get; set; }

        public DbSet<Country> Country { get; set; }

        //protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        //{
            //var config = modelBuilder.Entity<House>();
           // config.ToTable("House");
        //}
    }
}
