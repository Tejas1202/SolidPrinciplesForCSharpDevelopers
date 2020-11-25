﻿using System;

/// <summary>
/// Replaced this fat interface and it's implementation with smaller interfaces
/// Deprecated
/// </summary>
namespace PolicyRatingOrg.WithSolidPrinciples
{
    class DefaultRatingContext : IRatingContext
    {
        public RatingEngine Engine { get; set; }

        private readonly IPolicySource _policySource;
        public DefaultRatingContext(IPolicySource policySource)
        {
            _policySource = policySource;
        }

        public Policy GetPolicyFromJsonString(string policyJson)
        {
            return new JsonPolicySerializer().GetPolicyFromJsonString(policyJson);
        }

        public Policy GetPolicyFromXmlString(string policyXml)
        {
            throw new NotImplementedException();
        }

        public string LoadPolicyFromFile()
        {
            return _policySource.GetPolicyFromSource();
        }

        public string LoadPolicyFromURI(string uri)
        {
            throw new NotImplementedException();
        }

        public void Log(string message)
        {
            new ConsoleLogger().Log(message);
        }

        public void UpdateRating(decimal rating)
        {
            Engine.Rating = rating;
        }
    }
}