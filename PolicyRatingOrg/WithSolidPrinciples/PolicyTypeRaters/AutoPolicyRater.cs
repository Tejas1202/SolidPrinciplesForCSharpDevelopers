using System;

namespace PolicyRatingOrg.WithSolidPrinciples.PolicyTypeRaters
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(ConsoleLogger logger, RatingEngine engine)
            : base(logger, engine)
        {
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating AUTO policy...");
            _logger.Log("Validating policy.");

            if (String.IsNullOrEmpty(policy.Make))
            {
                _logger.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _engine.Rating = 1000m;
                }
                _engine.Rating = 900m;
            }
        }
    }
}