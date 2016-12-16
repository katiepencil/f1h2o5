namespace f1h2o5.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {

        // How do I do a stored procedure?
        //this.Database.SqlQuery<YourEntityType>("storedProcedureName",params);

        //something like this...?
        // var result = this.Database.SqlQuery<Driver>("GetAllDriverSummaries").ToList();


        // here's another possibility...
        // using(var context = new DatabaseContext())
        //   {
        //       var clientIdParameter = new SqlParameter("@ClientId", 4);
        //       var result = context.Database
        //           .SqlQuery<ResultForCampaign>("GetResultsForCampaign @ClientId", clientIdParameter)
        //             .ToList();
        //   }

        //...or another possibility...
        // var drivers = db.Database.SqlQuery<Driver>("dbo.GetAllDriverSummaries", name).SingleOrDefault();

            // ... or
       //var statesFromArgentina = context.Countries.SqlQuery("dbo.GetStatesFromCountry @p0", countryIso);

        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<RaceResultType> RaceResultTypes { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<DriverRunsRace> DriverRunsRaces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Drivers)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Locations)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.State_Province)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.DOB)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.Bio)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.DriverRunsRaces)
                .WithRequired(e => e.Driver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Races)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Race>()
                .Property(e => e.RaceName)
                .IsUnicode(false);

            modelBuilder.Entity<Race>()
                .HasMany(e => e.DriverRunsRaces)
                .WithRequired(e => e.Race)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RaceResultType>()
                .Property(e => e.ResultTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<RaceResultType>()
                .HasMany(e => e.DriverRunsRaces)
                .WithRequired(e => e.RaceResultType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.Boat)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.Sponsor)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.Manager)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Drivers)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DriverRunsRace>()
                .Property(e => e.RaceTime)
                .HasPrecision(18, 0);
        }
    }
}
