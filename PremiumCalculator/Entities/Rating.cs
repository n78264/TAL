using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PremiumCalculator.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Factor { get; set; }
        public virtual IEnumerable<OccupationRating> OccupationRatings { get; set; }
    }
}
