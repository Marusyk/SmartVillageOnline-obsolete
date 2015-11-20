using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Domain.Migrations
{
    class CustomDbConfiguration : DbConfiguration
    {
        public CustomDbConfiguration()
        {
            SetMigrationSqlGenerator(SqlProviderServices.ProviderInvariantName,
                () => new CustomSqlGenerator());
        }
    }
}
