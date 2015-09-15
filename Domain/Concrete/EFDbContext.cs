using System.Data.Entity;
using Domain.Abstract;
using System.Reflection;
using System.Linq;
using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;

namespace Domain.Concrete
{
    [DbConfigurationType(typeof(CustomDbConfiguration))]
    public class EFDbContext : DbContext   
    {
        public EFDbContext()
            :base("EFDbContext")
        {
            this.Configuration.ProxyCreationEnabled = true;
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // remove a convention to enable cascade delete for any required relationships
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();            

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }

    }
}
