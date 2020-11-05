namespace PolicyRatingOrg.WithSolidPrinciples.PolicyTypeRaters
{
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(ConsoleLogger logger, RatingEngine engine)
            : base(logger, engine)
        {
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Unknown policy type");
        }
    }
}
