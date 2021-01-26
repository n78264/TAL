namespace PremiumCalculator.Entities
{
    public class OccupationRating
    {
        public int OccupationId { get; set; }
        public int RatingId { get; set; }

        public virtual Occupation Occupation { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
