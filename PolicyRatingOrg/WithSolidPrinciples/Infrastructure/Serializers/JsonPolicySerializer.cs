using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PolicyRatingOrg.WithSolidPrinciples
{
    public class JsonPolicySerializer : IPolicySerializer
    {
        public Policy GetPolicyFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<Policy>(jsonString,
                new StringEnumConverter());
        }
    }
}
