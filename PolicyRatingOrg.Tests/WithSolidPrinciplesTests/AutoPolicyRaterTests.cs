using Moq;
using NUnit.Framework;
using PolicyRatingOrg.WithSolidPrinciples;
using PolicyRatingOrg.WithSolidPrinciples.PolicyTypeRaters;

namespace PolicyRatingOrg.Tests.WithSolidPrinciplesTests
{
    [TestFixture]
    class AutoPolicyRaterTests
    {
        [Test]
        public void Rate_WhenGivenPolicyWithoutMake_LogMakeRequiredMessage()
        {
            var policy = new Policy { Type = PolicyType.Auto };
            var logger = new Mock<ILogger>();
            var autoPolicyRater = new AutoPolicyRater(logger.Object);

            autoPolicyRater.Rate(policy);

            logger.Verify(l => l.Log("Auto policy must specify Make"));
        }

        [Test]
        public void Rate_WhenBMWWithDeductibleLessThan500_SetRatingTo1000()
        {
            var policy = new Policy { Type = PolicyType.Auto, Make = "BMW", Deductible = 250 };
            var autoPolicyRater = new AutoPolicyRater(new Mock<ILogger>().Object);

            var result = autoPolicyRater.Rate(policy);

            Assert.That(result, Is.EqualTo(1000));
        }
    }

    public class FakeRatingUpdater : IRatingUpdater
    {
        public decimal NewRating { get; private set; }
        public void UpdateRating(decimal rating)
        {
            NewRating = rating;
        }
    }
}
