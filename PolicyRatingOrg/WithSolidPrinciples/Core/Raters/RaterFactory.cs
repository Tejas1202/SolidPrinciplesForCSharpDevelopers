using PolicyRatingOrg.WithSolidPrinciples.PolicyTypeRaters;
using System;

namespace PolicyRatingOrg.WithSolidPrinciples
{
    // Can extend the behaviour by adding new type for PolicyRater
    public class RaterFactory
    {
        private readonly ILogger logger;
        public RaterFactory(ILogger logger)
        {
            this.logger = logger;
        }

        //// Using Reflection
        //public Rater Create(Policy policy)
        //{
        //    try
        //    {
        //        return (Rater)Activator.CreateInstance(
        //            Type.GetType($"PolicyRatingOrg.WithSolidPrinciples.PolicyTypeRaters.{policy.Type}PolicyRater"),
        //                new object[] { logger });
        //    }
        //    catch
        //    {
        //        // Here, if we return null and then handle in the calling code to run different behaviour based on null,
        //        // it violates OCP principle, hence we encapsulated that behaviour of logging Unknown Policy type in the type
        //        // itself i.e. UnknownPolicyRater
        //        return new UnknownPolicyRater(logger);
        //        // return null;
        //    }
        //}

        public Rater Create(Policy policy)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(logger);

                case PolicyType.Flood:
                    return new FloodPolicyRater(logger);

                case PolicyType.Land:
                    return new LandPolicyRater(logger);

                case PolicyType.Life:
                    return new LifePolicyRater(logger);

                default:
                    // currently this can't be reached 
                    return new UnknownPolicyRater(logger);
            }
        }
    }
}
