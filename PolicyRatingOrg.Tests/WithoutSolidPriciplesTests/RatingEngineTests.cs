using Newtonsoft.Json;
using NUnit.Framework;
using PolicyRatingOrg.WithoutSolidPrinciples;
using System.IO;

namespace PolicyRatingOrg.Tests.WithoutSolidPrincipleTests
{
    [TestFixture]
    public class RatingEngineTests
    {
        private RatingEngine _ratingEngine;

        [SetUp]
        public void Setup()
        {
            _ratingEngine = new RatingEngine();
        }

        /// <summary>
        /// Now as the Persistence logic (i.e. Reading json from File IO) is coupled inside the Rate method itself (violating SRP), we'd to first override the json file in that path
        /// and then test our functionality
        /// </summary>
        [Test]
        public void Rate_WhenBondAmountGreaterThan80PercentOfValuationForLandPolicy_ReturnsRatingOf5PercentOnBondAmount()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText(@"E:/Computer Science/C#/SolidPrinciplesForCSharpDevelopers/PolicyRatingOrg/PolicyRatingOrg/WithoutSolidPrinciples/policy.json", json);

            _ratingEngine.Rate();

            Assert.That(_ratingEngine.Rating, Is.EqualTo(0.05m * policy.BondAmount));
        }
    }
}