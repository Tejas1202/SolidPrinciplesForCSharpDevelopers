using System.IO;

namespace PolicyRatingOrg.WithSolidPrinciples
{
    public class FilePolicySource : IPolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText(@"WithSolidPrinciples\policy.json");
        }
    }
}
