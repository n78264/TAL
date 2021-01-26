using PremiumCalculator.Entities;
using PremiumCalculator.Models;
using System.Collections.Generic;

namespace PremiumCalculator.Repositories
{
    public interface IRepository
    {
        Occupation GetOccupationById(int occupationId);
        IEnumerable<Occupation> GetOccupations();
        IEnumerable<OccupationRatingViewModel> GetRatingFactor();
        OccupationRatingViewModel GetRatingFactorById(int occupationId);

        Rating GetRatingById(int ratingId);
        IEnumerable<Rating> GetRatings();


    }
}
