using NUnit.Framework;
using PolicyRatingOrg.WithSolidPrinciples;

namespace PolicyRatingOrg.Tests.WithSolidPrinciplesTests
{
    /// <summary>
    /// Very easy to unit test as JsonDeserialization of Policy is kept as a seperate responsibility and not coupled with Rate method unlike previous one
    /// </summary>
    [TestFixture]
    class JsonPolicySerializerTests
    {
        private JsonPolicySerializer _serializer;

        [SetUp]
        public void SetUp()
        {
            _serializer = new JsonPolicySerializer();
        }

        [Test]
        public void GetPolicyFromJsonString_WhenJsonEmpty_ReturnDefaultPolicy()
        {
            var inputJson = "{}";
            var policy = new Policy();

            var result = _serializer.GetPolicyFromJsonString(inputJson);

            AssertPoliciesEqual(result, policy);
        }

        [Test]
        public void GetPolicyFromJsonString_WhenPolicyTypeAuto_ReturnsAutoPolicy()
        {
            var inputJson = @"{""type"" : ""Auto"", ""make"" : ""BMW""}";
            var policy = new Policy { Type = PolicyType.Auto, Make = "BMW" };

            var result = _serializer.GetPolicyFromJsonString(inputJson);

            AssertPoliciesEqual(result, policy);
        }

        private static void AssertPoliciesEqual(Policy result, Policy policy)
        {
            Assert.That(policy.Address, Is.EqualTo(result.Address));
            Assert.That(policy.Amount, Is.EqualTo(result.Amount));
            Assert.That(policy.BondAmount, Is.EqualTo(result.BondAmount));
            Assert.That(policy.DateOfBirth, Is.EqualTo(result.DateOfBirth));
            Assert.That(policy.Deductible, Is.EqualTo(result.Deductible));
            Assert.That(policy.FullName, Is.EqualTo(result.FullName));
            Assert.That(policy.IsSmoker, Is.EqualTo(result.IsSmoker));
            Assert.That(policy.Make, Is.EqualTo(result.Make));
            Assert.That(policy.Miles, Is.EqualTo(result.Miles));
            Assert.That(policy.Model, Is.EqualTo(result.Model));
            Assert.That(policy.Type, Is.EqualTo(result.Type));
            Assert.That(policy.Valuation, Is.EqualTo(result.Valuation));
            Assert.That(policy.Year, Is.EqualTo(result.Year));
        }
    }
}
