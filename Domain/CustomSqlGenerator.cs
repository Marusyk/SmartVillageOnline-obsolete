using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace Domain
{
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
}
