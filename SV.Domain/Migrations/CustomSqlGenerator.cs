using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;

namespace Domain.Migrations
{
    public class CustomSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddForeignKeyOperation addForeignKeyOperation)
        {
            addForeignKeyOperation.Name = GetFkName(addForeignKeyOperation.Name);
            base.Generate(addForeignKeyOperation);
        }

        protected override void Generate(DropForeignKeyOperation dropForeignKeyOperation)
        {
            dropForeignKeyOperation.Name = GetFkName(dropForeignKeyOperation.Name);
            base.Generate(dropForeignKeyOperation);         
        }

        protected override void Generate(CreateTableOperation table)
        {
            table.PrimaryKey.Name = GetPkName(table.Name);
            base.Generate(table);
        }

        private static string GetFkName(string foreignKeyName)
        {  
            return foreignKeyName.Replace("dbo.", "");
        }

        private static string GetPkName(string primaryKeyTable)
        {
            primaryKeyTable = primaryKeyTable.Replace("dbo.", "");
            return "SYS_" + primaryKeyTable + "_PKY";
        }
    }
}
