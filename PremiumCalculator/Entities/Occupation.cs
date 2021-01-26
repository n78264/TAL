using System.ComponentModel.DataAnnotations;

namespace PremiumCalculator.Entities
{
    public class Occupation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual OccupationRating OccupationRatings { get; set; }
    }
}
