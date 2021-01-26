using PremiumCalculator.DbContexts;
using PremiumCalculator.Entities;
using PremiumCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PremiumCalculator.Repositories
{
    public class Repository : IRepository
    {
        private SqlServerDbContext _context;
        public Repository(SqlServerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Occupation> GetOccupations()
        {
            return _context.Occupations.ToList();
        }

        public Occupation GetOccupationById(int occupationId)
        {
            return _context.Occupations.FirstOrDefault(x => x.Id == occupationId);
        }

        public IEnumerable<OccupationRatingViewModel> GetRatingFactor()
        {
            var query =
            from d in _context.Occupations
            join c in _context.OccupationRatings on d.Id equals c.OccupationId
            join s in _context.Ratings on c.RatingId equals s.Id
            select new OccupationRatingViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Factor = s.Factor
            };
            return query.ToList();
        }

        public OccupationRatingViewModel GetRatingFactorById(int occupationId)
        {
            var query = GetRatingFactor();
            return query.FirstOrDefault(x => x.Id == occupationId);
        }

        public IEnumerable<Rating> GetRatings()
        {
            return _context.Ratings.ToList();
        }

        public Rating GetRatingById(int ratingId)
        {
            return _context.Ratings.FirstOrDefault(x => x.Id == ratingId);
        }
    }
}
