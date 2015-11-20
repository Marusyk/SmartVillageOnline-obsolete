using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;

namespace Domain.Migrations
{
    public class CustomSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddForeignKeyOperation addForeignKeyOperation)
        {
            addForeignKeyOperation.Name = getFkName(addForeignKeyOperation.Name);
            base.Generate(addForeignKeyOperation);
        }

        protected override void Generate(DropForeignKeyOperation dropForeignKeyOperation)
        {
            dropForeignKeyOperation.Name = getFkName(dropForeignKeyOperation.Name);
            base.Generate(dropForeignKeyOperation);         
        }

        protected override void Generate(CreateTableOperation table)
        {
            table.PrimaryKey.Name = getPkName(table.Name);
            base.Generate(table);
        }

        private static string getFkName(string foreignKeyName)
        {  
            return foreignKeyName.Replace("dbo.", "");
        }

        private static string getPkName(string primaryKeyTable)
        {
            primaryKeyTable = primaryKeyTable.Replace("dbo.", "");
            return "SYS_" + primaryKeyTable + "_PKY";
        }
    }
}
