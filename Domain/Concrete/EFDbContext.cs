using Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain.Concrete
{
    public class EFDbContext<T> : DbContext where T : class
    {

        public DbSet<T> TableName { get; set; }

    }
}
