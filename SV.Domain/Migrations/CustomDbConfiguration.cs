using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Domain.Migrations
{
    internal class CustomDbConfiguration : DbConfiguration
    {
        public CustomDbConfiguration()
        {
            SetMigrationSqlGenerator(SqlProviderServices.ProviderInvariantName,
                () => new CustomSqlGenerator());
        }
    }
}
