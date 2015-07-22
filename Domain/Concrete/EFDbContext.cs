using System.Data.Entity;
using Domain.Abstract;
using System.Reflection;
using System.Linq;
using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Migrations.Model;

namespace Domain.Concrete
{
    [DbConfigurationType(typeof(CustomDbConfiguration))]
    public class EFDbContext : DbContext   
    {
        public EFDbContext()
            :base("EFDbContext")
        { }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
    public class CustomSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddForeignKeyOperation addForeignKeyOperation)
        {
            addForeignKeyOperation.Name = getFkName(addForeignKeyOperation.PrincipalTable,
                addForeignKeyOperation.DependentTable, addForeignKeyOperation.DependentColumns.ToArray());
            base.Generate(addForeignKeyOperation);
        }

        protected override void Generate(DropForeignKeyOperation dropForeignKeyOperation)
        {
            dropForeignKeyOperation.Name = getFkName(dropForeignKeyOperation.PrincipalTable,
                dropForeignKeyOperation.DependentTable, dropForeignKeyOperation.DependentColumns.ToArray());
            base.Generate(dropForeignKeyOperation);
        }

        private static string getFkName(string primaryKeyTable, string foreignKeyTable, params string[] foreignTableFields)
        {
            //District_FKC_Region 
            primaryKeyTable = primaryKeyTable.Replace("dbo.", "");
            foreignKeyTable = foreignKeyTable.Replace("dbo.", "");
            return primaryKeyTable + "_FK_" + foreignKeyTable;
        }
    }

    public class CustomDbConfiguration : DbConfiguration
    {
        public CustomDbConfiguration()
        {
            SetMigrationSqlGenerator(SqlProviderServices.ProviderInvariantName,
                () => new CustomSqlGenerator());
        }
    }
}
