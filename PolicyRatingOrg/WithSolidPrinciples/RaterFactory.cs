using PolicyRatingOrg.WithSolidPrinciples.PolicyTypeRaters;
using System;

namespace PolicyRatingOrg.WithSolidPrinciples
{
    // Can extend the behaviour by adding new type for PolicyRater
    public class RaterFactory
    {
        // Using Reflection
        //public Rater Create(Policy policy, IRatingContext context)
        //{
        //    try
        //    {
        //        return (Rater)Activator.CreateInstance(
        //            Type.GetType($"PolicyRatingOrg.WithSolidPrinciples.PolicyTypeRaters.{policy.Type}PolicyRater"),
        //                new object[] { context });
        //    }
        //    catch
        //    {
        //        // Here, if we return null and then handle in the calling code to run different behaviour based on null,
        //        // it violates OCP principle, hence we encapsulated that behaviour of logging Unknown Policy type in the type
        //        // itself i.e. UnknownPolicyRater
        //        return new UnknownPolicyRater(context);
        //        // return null;
        //    }
        //}

        public Rater Create(Policy policy, IRatingContext context)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(context);

                case PolicyType.Flood:
                    return new FloodPolicyRater(context);

                case PolicyType.Land:
                    return new LandPolicyRater(context);

                case PolicyType.Life:
                    return new LifePolicyRater(context);

                default:
                    // currently this can't be reached 
                    return new UnknownPolicyRater(context);
            }
        }
    }
}
