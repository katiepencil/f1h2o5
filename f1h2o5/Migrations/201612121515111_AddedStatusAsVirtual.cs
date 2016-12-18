namespace f1h2o5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatusAsVirtual : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Country",
            //    c => new
            //        {
            //            CountryId = c.Int(nullable: false, identity: true),
            //            CountryName = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.CountryId);

            //CreateTable(
            //    "dbo.Driver",
            //    c => new
            //        {
            //            DriverId = c.Int(nullable: false, identity: true),
            //            FirstName = c.String(nullable: false, maxLength: 128),
            //            LastName = c.String(nullable: false, maxLength: 128),
            //            Address1 = c.String(maxLength: 128),
            //            Address2 = c.String(maxLength: 128),
            //            City = c.String(maxLength: 128),
            //            StateProvince = c.String(name: "State/Province", maxLength: 128),
            //            PostalCode = c.String(maxLength: 128),
            //            CountryId = c.Int(nullable: false),
            //            Phone = c.String(maxLength: 128),
            //            Email = c.String(maxLength: 128),
            //            DOB = c.String(maxLength: 128),
            //            ImageUrl = c.String(maxLength: 128),
            //            Bio = c.String(maxLength: 500),
            //            TeamId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.DriverId)
            //    .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
            //    .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
            //    .Index(t => t.CountryId)
            //    .Index(t => t.TeamId);

            //CreateTable(
            //    "dbo.DriverRunsRace",
            //    c => new
            //        {
            //            DriverId = c.Int(nullable: false),
            //            RaceId = c.Int(nullable: false),
            //            ResultTypeId = c.Int(nullable: false),
            //            RaceTime = c.Decimal(precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => new { t.DriverId, t.RaceId, t.ResultTypeId })
            //    .ForeignKey("dbo.Driver", t => t.DriverId, cascadeDelete: true)
            //    .ForeignKey("dbo.Race", t => t.RaceId, cascadeDelete: true)
            //    .ForeignKey("dbo.RaceResultType", t => t.ResultTypeId, cascadeDelete: true)
            //    .Index(t => t.DriverId)
            //    .Index(t => t.RaceId)
            //    .Index(t => t.ResultTypeId);

            //CreateTable(
            //    "dbo.Race",
            //    c => new
            //        {
            //            RaceId = c.Int(nullable: false, identity: true),
            //            RaceName = c.String(nullable: false, maxLength: 128),
            //            LocationId = c.Int(nullable: false),
            //            RaceYear = c.Int(nullable: false),
            //            StartDate = c.DateTime(nullable: false, storeType: "date"),
            //            EndDate = c.DateTime(nullable: false, storeType: "date"),
            //        })
            //    .PrimaryKey(t => t.RaceId)
            //    .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
            //    .Index(t => t.LocationId);

            //CreateTable(
            //    "dbo.Location",
            //    c => new
            //    {
            //        LocationId = c.Int(nullable: false, identity: true),
            //        City = c.String(nullable: false, maxLength: 128),
            //        CountryId = c.Int(nullable: false),
            //    })
            //    .PrimaryKey(t => t.LocationId)
            //    .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
            //    .Index(t => t.CountryId);

            //CreateTable(
            //    "dbo.RaceResultType",
            //    c => new
            //        {
            //            ResultTypeId = c.Int(nullable: false, identity: true),
            //            ResultTypeName = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.ResultTypeId);

            //CreateTable(
            //    "dbo.Team",
            //    c => new
            //        {
            //            TeamId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 128),
            //            CountryId = c.Int(nullable: false),
            //            Boat = c.String(maxLength: 128),
            //            Sponsor = c.String(maxLength: 128),
            //            Manager = c.String(maxLength: 128),
            //            TeamYear = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.TeamId)
            //    .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
            //    .Index(t => t.CountryId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Driver", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Team", "CountryId", "dbo.Country");
            DropForeignKey("dbo.DriverRunsRace", "ResultTypeId", "dbo.RaceResultType");
            DropForeignKey("dbo.Race", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Location", "CountryId", "dbo.Country");
            DropForeignKey("dbo.DriverRunsRace", "RaceId", "dbo.Race");
            DropForeignKey("dbo.DriverRunsRace", "DriverId", "dbo.Driver");
            DropForeignKey("dbo.Driver", "CountryId", "dbo.Country");
            DropIndex("dbo.Team", new[] { "CountryId" });
            DropIndex("dbo.Location", new[] { "CountryId" });
            DropIndex("dbo.Race", new[] { "LocationId" });
            DropIndex("dbo.DriverRunsRace", new[] { "ResultTypeId" });
            DropIndex("dbo.DriverRunsRace", new[] { "RaceId" });
            DropIndex("dbo.DriverRunsRace", new[] { "DriverId" });
            DropIndex("dbo.Driver", new[] { "TeamId" });
            DropIndex("dbo.Driver", new[] { "CountryId" });
            DropTable("dbo.Team");
            DropTable("dbo.RaceResultType");
            DropTable("dbo.Location");
            DropTable("dbo.Race");
            DropTable("dbo.DriverRunsRace");
            DropTable("dbo.Driver");
            DropTable("dbo.Country");
        }
    }
}
