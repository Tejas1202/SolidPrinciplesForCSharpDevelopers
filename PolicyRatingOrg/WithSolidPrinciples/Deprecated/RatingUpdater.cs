using System;
using System.Collections.Generic;
using System.Text;

// Deprecated
namespace PolicyRatingOrg.WithSolidPrinciples
{
    public class RatingUpdater : IRatingUpdater
    {
        private readonly RatingEngine _engine;
        public RatingUpdater(RatingEngine engine)
        {
            _engine = engine;
        }

        public void UpdateRating(decimal rating)
        {
            _engine.Rating = rating;
        }
    }
}
