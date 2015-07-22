namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M012207 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityID = c.Int(nullable: false),
                        StreetID = c.Int(),
                        PostCode = c.Int(),
                        BuildNr = c.String(maxLength: 10),
                        FlatNr = c.String(maxLength: 10),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.CityID)
                .ForeignKey("dbo.Street", t => t.StreetID)
                .Index(t => t.CityID)
                .Index(t => t.StreetID);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityTypeID = c.Int(nullable: false),
                        DistrictID = c.Int(),
                        RegionID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CityType", t => t.CityTypeID)
                .ForeignKey("dbo.District", t => t.DistrictID)
                .ForeignKey("dbo.Region", t => t.RegionID)
                .Index(t => t.CityTypeID)
                .Index(t => t.DistrictID)
                .Index(t => t.RegionID);
            
            CreateTable(
                "dbo.CityType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegionID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Region", t => t.RegionID)
                .Index(t => t.RegionID);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Country", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Street",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StreetTypeID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StreetType", t => t.StreetTypeID)
                .Index(t => t.StreetTypeID);
            
            CreateTable(
                "dbo.StreetType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.House",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HouseNr = c.String(nullable: false, maxLength: 10),
                        KadastrNr = c.String(maxLength: 10),
                        BuildNr = c.String(nullable: false, maxLength: 10),
                        AddressID = c.Int(nullable: false),
                        PhoneNr = c.String(maxLength: 12),
                        PhoneCode = c.String(maxLength: 5),
                        FaxNr = c.String(maxLength: 12),
                        Year = c.Int(),
                        Code = c.String(maxLength: 50),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        Name = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        DateBith = c.DateTime(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        IsResident = c.Boolean(nullable: false),
                        AddressBithId = c.Int(),
                        AddressLiveId = c.Int(),
                        NationalityId = c.Int(),
                        IdentificationCode = c.String(maxLength: 10),
                        PassSeria = c.String(maxLength: 2),
                        PassNr = c.Int(),
                        PassDate = c.DateTime(),
                        PassAuthorityId = c.Int(),
                        FamilyStatusId = c.Int(),
                        CitizenshipId = c.Int(),
                        CatalogId = c.Int(nullable: false),
                        IsSojourn = c.Boolean(nullable: false),
                        Photo = c.Byte(),
                        PadFirstName = c.String(maxLength: 60),
                        PadName = c.String(maxLength: 60),
                        PadLastName = c.String(maxLength: 60),
                        DatFirstName = c.String(maxLength: 60),
                        DatName = c.String(maxLength: 60),
                        DatLastName = c.String(maxLength: 60),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SYS_Dictionary",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
                        IsStatic = c.Boolean(nullable: false),
                        LastUpdDT = c.DateTime(nullable: false),
                        LastUpdUS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Street", "StreetTypeID", "dbo.StreetType");
            DropForeignKey("dbo.Address", "StreetID", "dbo.Street");
            DropForeignKey("dbo.District", "RegionID", "dbo.Region");
            DropForeignKey("dbo.Region", "CountryID", "dbo.Country");
            DropForeignKey("dbo.City", "RegionID", "dbo.Region");
            DropForeignKey("dbo.City", "DistrictID", "dbo.District");
            DropForeignKey("dbo.City", "CityTypeID", "dbo.CityType");
            DropForeignKey("dbo.Address", "CityID", "dbo.City");
            DropIndex("dbo.Street", new[] { "StreetTypeID" });
            DropIndex("dbo.Region", new[] { "CountryID" });
            DropIndex("dbo.District", new[] { "RegionID" });
            DropIndex("dbo.City", new[] { "RegionID" });
            DropIndex("dbo.City", new[] { "DistrictID" });
            DropIndex("dbo.City", new[] { "CityTypeID" });
            DropIndex("dbo.Address", new[] { "StreetID" });
            DropIndex("dbo.Address", new[] { "CityID" });
            DropTable("dbo.SYS_Dictionary");
            DropTable("dbo.Person");
            DropTable("dbo.House");
            DropTable("dbo.Animals");
            DropTable("dbo.StreetType");
            DropTable("dbo.Street");
            DropTable("dbo.Country");
            DropTable("dbo.Region");
            DropTable("dbo.District");
            DropTable("dbo.CityType");
            DropTable("dbo.City");
            DropTable("dbo.Address");
        }
    }
}
