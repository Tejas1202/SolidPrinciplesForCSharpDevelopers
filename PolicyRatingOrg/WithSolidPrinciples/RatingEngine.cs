namespace PolicyRatingOrg.WithSolidPrinciples
{
    public class RatingEngine
    {
        // Hence Rate method still does what it does but we've delegated the how of Logging, Persistence etc. to other classes (SRP)
        public IRatingContext Context { get; set; } = new DefaultRatingContext();
        public decimal Rating { get; set; }

        public RatingEngine()
        {
            Context.Engine = this;
        }

        public void Rate()
        {
            Context.Log("Starting rate.");

            Context.Log("Loading policy.");

            string policyJson = Context.LoadPolicyFromFile();

            var policy = Context.GetPolicyFromJsonString(policyJson);

            var factory = new RaterFactory();

            var rater = Context.CreateRaterForPolicy(policy, Context);
            rater.Rate(policy);

            Context.Log("Rating completed.");
        }
    }
}
