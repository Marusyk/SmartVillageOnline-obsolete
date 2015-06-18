namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        HouseID = c.Int(nullable: false, identity: true),
                        HouseNr = c.String(),
                        KadastrNr = c.String(),
                        BuildNr = c.String(),
                        AddressID = c.Int(nullable: false),
                        PhoneNr = c.String(),
                        PhoneCode = c.String(),
                        FaxNr = c.String(),
                        Year = c.Int(nullable: false),
                        Code = c.String(),
                        LastUpdUS = c.String(),
                    })
                .PrimaryKey(t => t.HouseID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Countries");
            DropTable("dbo.Houses");
        }
    }
}
