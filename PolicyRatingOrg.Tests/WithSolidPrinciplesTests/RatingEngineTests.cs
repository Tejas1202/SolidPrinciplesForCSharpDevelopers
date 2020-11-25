using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using PolicyRatingOrg.WithSolidPrinciples;
using System.Collections.Generic;

namespace PolicyRatingOrg.Tests.WithSolidPrinciplesTests
{
    [TestFixture]
    public class RatingEngineTests
    {
        private RatingEngine _ratingEngine;
        private Mock<ILogger> _logger;
        private Mock<IPolicySource> _policySource;
        private Mock<IPolicySerializer> _policySerializer;
        private RaterFactory _raterFactory;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger>();
            _policySource = new Mock<IPolicySource>();
            _policySerializer = new Mock<IPolicySerializer>();
            _raterFactory = new RaterFactory(_logger.Object);
            _ratingEngine = new RatingEngine(_logger.Object, _policySource.Object, _policySerializer.Object, _raterFactory);
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
            _policySource.Setup(p => p.GetPolicyFromSource()).Returns(json);
            _policySerializer.Setup(p => p.GetPolicyFromJsonString(json)).Returns(policy);
            //File.WriteAllText(@"E:/Computer Science/C#/SolidPrinciplesForCSharpDevelopers/PolicyRatingOrg/PolicyRatingOrg/WithoutSolidPrinciples/policy.json", json);

            _ratingEngine.Rate();

            Assert.That(_ratingEngine.Rating, Is.EqualTo(0.05m * policy.BondAmount));
        }

        [Test]
        public void Rate_WhenCalled_LogsStartLoadAndCompleteMessages()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };
            var invocations = new List<string>();
            _logger.Setup(l => l.Log(It.IsAny<string>())).Callback<string>((message) => invocations.Add(message));
            string json = JsonConvert.SerializeObject(policy);
            _policySource.Setup(p => p.GetPolicyFromSource()).Returns(json);
            _policySerializer.Setup(p => p.GetPolicyFromJsonString(json)).Returns(policy);

            _ratingEngine.Rate();

            Assert.That(invocations.Contains("Starting rate."));
            Assert.That(invocations.Contains("Loading policy."));
            Assert.That(invocations.Contains("Rating completed."));
        }
    }

    public class FakeLogger : ILogger
    {
        public List<string> LoggedMessages { get; } = new List<string>();
        public void Log(string message)
        {
            LoggedMessages.Add(message);
        }
    }
}
