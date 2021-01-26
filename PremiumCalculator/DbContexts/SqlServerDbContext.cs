using Microsoft.EntityFrameworkCore;
using PremiumCalculator.Entities;

namespace PremiumCalculator.DbContexts
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
            : base(options)
        {

        }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<OccupationRating> OccupationRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OccupationRating>()
            .HasKey(p => new { p.OccupationId, p.RatingId });

            modelBuilder.Entity<Occupation>().HasData(new Occupation
            {   Id=10001,
                Name = "Cleaner"
            });
            modelBuilder.Entity<Occupation>().HasData(new Occupation
            {
                Id = 10002,
                Name = "Doctor"
            });
            modelBuilder.Entity<Occupation>().HasData(new Occupation
            {
                Id = 10003,
                Name = "Author"
            });
            modelBuilder.Entity<Occupation>().HasData(new Occupation
            {
                Id = 10004,
                Name = "Farmer"
            });
            modelBuilder.Entity<Occupation>().HasData(new Occupation
            {
                Id = 10005,
                Name = "Mechanic"
            });
            modelBuilder.Entity<Occupation>().HasData(new Occupation
            {
                Id = 10006,
                Name = "Florist"
            });

            modelBuilder.Entity<Rating>().HasData(new Rating
            {
                Id = 20001,
                Name = "Professional", 
                Factor= 1.0
            });
            modelBuilder.Entity<Rating>().HasData(new Rating
            {
                Id = 20002,
                Name = "White Collar",
                Factor = 1.25
            });
            modelBuilder.Entity<Rating>().HasData(new Rating
            {
                Id = 20003,
                Name = "Light Manual",
                Factor = 1.50
            });
            modelBuilder.Entity<Rating>().HasData(new Rating
            {
                Id = 20004,
                Name = "Heavy Manual",
                Factor = 1.75
            });


            modelBuilder.Entity<OccupationRating>().HasData(new OccupationRating
            {
                OccupationId = 10001,
                RatingId = 20003
            });
            modelBuilder.Entity<OccupationRating>().HasData(new OccupationRating
            {
                OccupationId = 10002,
                RatingId = 20001
            });
            modelBuilder.Entity<OccupationRating>().HasData(new OccupationRating
            {
                OccupationId = 10003,
                RatingId = 20002
            });
            modelBuilder.Entity<OccupationRating>().HasData(new OccupationRating
            {
                OccupationId = 10004,
                RatingId = 20004
            });
            modelBuilder.Entity<OccupationRating>().HasData(new OccupationRating
            {
                OccupationId = 10005,
                RatingId = 20004
            });
            modelBuilder.Entity<OccupationRating>().HasData(new OccupationRating
            {
                OccupationId = 10006,
                RatingId = 20003
            });
        }
    }
}
