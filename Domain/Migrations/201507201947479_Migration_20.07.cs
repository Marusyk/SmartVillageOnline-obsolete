namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_2007 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityID = c.Int(nullable: false),
                        StreetID = c.Int(nullable: false),
                        PostCode = c.Int(nullable: false),
                        BuildNr = c.String(),
                        FlatNr = c.String(),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CityType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Street",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StreetTypeID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StreetType", t => t.StreetTypeID, cascadeDelete: true, name: "Street_FKC_StreetType")
                .Index(t => t.StreetTypeID);
            
            CreateTable(
                "dbo.StreetType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.House",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HouseNr = c.String(nullable: false),
                        KadastrNr = c.String(),
                        BuildNr = c.String(nullable: false),
                        AddressID = c.Int(nullable: false),
                        PhoneNr = c.String(),
                        PhoneCode = c.String(),
                        FaxNr = c.String(),
                        Year = c.Int(),
                        Code = c.String(),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateBith = c.DateTime(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        IsResident = c.Boolean(nullable: false),
                        AddressBithId = c.Int(nullable: false),
                        AddressLiveId = c.Int(nullable: false),
                        NationalityId = c.Int(nullable: false),
                        IdentificationCode = c.String(maxLength: 10),
                        PassSeria = c.String(maxLength: 2),
                        PassNr = c.Int(nullable: false),
                        PassDate = c.DateTime(nullable: false),
                        PassAuthorityId = c.Int(nullable: false),
                        FamilyStatusId = c.Int(nullable: false),
                        CitizenshipId = c.Int(nullable: false),
                        CatalogId = c.Int(nullable: false),
                        IsSojourn = c.Boolean(nullable: false),
                        Photo = c.Byte(nullable: false),
                        PadFirstName = c.String(),
                        PadName = c.String(),
                        PadLastName = c.String(),
                        DatFirstName = c.String(),
                        DatName = c.String(),
                        DatLastName = c.String(),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SYS_Dictionary",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        IsStatic = c.Boolean(nullable: false),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Street", "Street_FKC_StreetType");
            DropIndex("dbo.Street", new[] { "StreetTypeID" });
            DropTable("dbo.SYS_Dictionary");
            DropTable("dbo.Person");
            DropTable("dbo.House");
            DropTable("dbo.StreetType");
            DropTable("dbo.Street");
            DropTable("dbo.Country");
            DropTable("dbo.CityType");
            DropTable("dbo.Animals");
            DropTable("dbo.Address");
        }
    }
}
