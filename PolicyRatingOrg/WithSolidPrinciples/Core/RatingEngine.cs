namespace PolicyRatingOrg.WithSolidPrinciples
{
    public class RatingEngine
    {
        // Hence Rate method still does what it does but we've delegated the how of Logging, Persistence etc. to other classes (SRP)
        public decimal Rating { get; set; }

        private readonly ILogger _logger;
        private readonly IPolicySource _policySource;
        private readonly IPolicySerializer _policySerializer;
        private readonly RaterFactory _raterFactory;
        public RatingEngine(ILogger logger, 
            IPolicySource policySource, 
            IPolicySerializer policySerializer,
            RaterFactory raterFactory)
        {
            _logger = logger;
            _policySource = policySource;
            _policySerializer = policySerializer;
            _raterFactory = raterFactory;
        }

        public void Rate()
        {
            _logger.Log("Starting rate.");

            _logger.Log("Loading policy.");

            string policyString = _policySource.GetPolicyFromSource();

            var policy = _policySerializer.GetPolicyFromJsonString(policyString);

            var rater = _raterFactory.Create(policy);
            Rating = rater.Rate(policy);

            _logger.Log("Rating completed.");
        }
    }
}