namespace PolicyRatingOrg.WithSolidPrinciples
{
    public abstract class Rater
    {
        protected readonly ConsoleLogger _logger;
        protected readonly RatingEngine _engine;

        public Rater(ConsoleLogger logger, RatingEngine engine)
        {
            _logger = logger;
            _engine = engine;
        }

        public abstract void Rate(Policy policy);
    }
}
