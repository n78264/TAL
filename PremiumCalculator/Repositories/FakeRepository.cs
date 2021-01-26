using PremiumCalculator.Entities;
using PremiumCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace PremiumCalculator.Repositories
{
    public class FakeRepository : IRepository
    {
        public IEnumerable<Occupation> GetOccupations()
        {
            return new List<Occupation>
                {
                new Occupation { Id = 10001, Name = "Cleaner" },
                new Occupation { Id = 10002, Name = "Doctor" },
                new Occupation { Id = 10003, Name = "Author" },
                new Occupation { Id = 10004, Name = "Farmer" },
                new Occupation { Id = 10005, Name = "Mechanic" },
                new Occupation { Id = 10006, Name = "Florist" }
            };
        }

        public Occupation GetOccupationById(int occupationId)
        {
            return GetOccupations().FirstOrDefault(x => x.Id == occupationId);
        }

        public IEnumerable<OccupationRatingViewModel> GetRatingFactor()
        {
            return new List<OccupationRatingViewModel>()
            {
                new OccupationRatingViewModel() {Id=10002,Name="Doctor",Factor=1.00},
                new OccupationRatingViewModel() {Id=10003,Name="Author",Factor=1.25},
                new OccupationRatingViewModel() {Id=10001,Name="Cleaner",Factor=1.50},
                new OccupationRatingViewModel() {Id=10006,Name="Florist",Factor=1.50},
                new OccupationRatingViewModel() {Id=10004,Name="Farmer",Factor=1.75},
                new OccupationRatingViewModel() {Id=10005,Name="Mechanic",Factor=1.75}
            };
        }

        public OccupationRatingViewModel GetRatingFactorById(int occupationId)
        {
            var query = GetRatingFactor();
            return query.FirstOrDefault(x => x.Id == occupationId);
        }

        public IEnumerable<Rating> GetRatings()
        {
            return new List<Rating>()
            {
                new Rating() { Id = 20001,Name = "Professional",Factor = 1.00},
                new Rating() { Id = 20002,Name = "White Collar",Factor = 1.25},
                new Rating() { Id = 20003,Name = "Light Manual",Factor = 1.50},
                new Rating() { Id = 20004,Name = "Heavy Manual",Factor = 1.75}
            };
        }

        public Rating GetRatingById(int ratingId)
        {
            return GetRatings().FirstOrDefault(x => x.Id == ratingId);
        }
    }
}
