namespace PolicyRatingOrg.WithSolidPrinciples
{
    public class RatingEngine
    {
        // Hence Rate method still does what it does but we've delegated the how of Logging, Persistence etc. to other classes (SRP)
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        private readonly FilePolicySource _policySource = new FilePolicySource();
        private readonly JsonPolicySerializer _policySerializer = new JsonPolicySerializer();

        public decimal Rating { get; set; }
        public void Rate()
        {
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            string policyJson = _policySource.GetPolicyFromSource();

            var policy = _policySerializer.GetPolicyFromJsonString(policyJson);

            var factory = new RaterFactory();

            var rater = factory.Create(policy, this);
            rater.Rate(policy);

            Logger.Log("Rating completed.");
        }
    }
}
