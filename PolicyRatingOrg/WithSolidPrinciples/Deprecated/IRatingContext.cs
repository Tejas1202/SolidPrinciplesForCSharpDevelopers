// Interface that is now used by RatingEngine instead of seperate properties of ConsoleLogger, FilePolicySource etc.
// Deprecated now
namespace PolicyRatingOrg.WithSolidPrinciples
{
    public interface IRatingContext : ILogger, IRatingUpdater
    {
        string LoadPolicyFromFile();
        string LoadPolicyFromURI(string uri);
        Policy GetPolicyFromJsonString(string policyJson);
        Policy GetPolicyFromXmlString(string policyXml);
        RatingEngine Engine { get; set; }
    }
}