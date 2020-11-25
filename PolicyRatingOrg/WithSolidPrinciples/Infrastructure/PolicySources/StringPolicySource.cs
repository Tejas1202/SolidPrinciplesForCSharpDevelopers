namespace PolicyRatingOrg.WithSolidPrinciples.Infrastructure.PolicySources
{
    public class StringPolicySource : IPolicySource
    {
        public string PolicyString { get; set; } = string.Empty;
        public string GetPolicyFromSource()
        {
            return PolicyString;
        }
    }
}
