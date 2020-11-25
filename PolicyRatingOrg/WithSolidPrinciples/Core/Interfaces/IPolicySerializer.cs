namespace PolicyRatingOrg.WithSolidPrinciples
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromJsonString(string jsonString);
    }
}
