using PolicyRatingOrg.WithSolidPrinciples.PolicyTypeRaters;
using System;

namespace PolicyRatingOrg.WithSolidPrinciples
{
    // Can extend the behaviour by adding new type for PolicyRater
    public class RaterFactory
    {
        // Using Reflection
        //public Rater Create(Policy policy, RatingEngine engine)
        //{
        //    try
        //    {
        //        return (Rater)Activator.CreateInstance(
        //            Type.GetType($"PolicyRatingOrg.WithSolidPrinciples.PolicyTypeRaters.{policy.Type}PolicyRater"),
        //                new object[] { engine, engine.Logger });
        //    }
        //    catch
        //    {
        //        // Here, if we return null and then handle in the calling code to run different behaviour based on null,
        //        // it violates OCP principle, hence we encapsulated that behaviour of logging Unknown Policy type in the type
        //        // itself i.e. UnknownPolicyRater
        //        return new UnknownPolicyRater(engine.Logger, engine);
        //        // return null;
        //    }
        //}

        public Rater Create(Policy policy, RatingEngine engine)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine.Logger, engine);

                case PolicyType.Flood:
                    return new FloodPolicyRater(engine.Logger, engine);

                case PolicyType.Land:
                    return new LandPolicyRater(engine.Logger, engine);

                case PolicyType.Life:
                    return new LifePolicyRater(engine.Logger, engine);

                default:
                    // currently this can't be reached 
                    return new UnknownPolicyRater(engine.Logger, engine);
            }
        }
    }
}
