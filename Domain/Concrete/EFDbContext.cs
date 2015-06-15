using Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<House> House { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            //var config = modelBuilder.Entity<House>();
           // config.ToTable("House");
        }
    }
}
