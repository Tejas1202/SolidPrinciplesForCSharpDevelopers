using Microsoft.AspNetCore.Mvc;
using PolicyRatingOrg.WithSolidPrinciples;
using PolicyRatingOrg.WithSolidPrinciples.Infrastructure.PolicySources;

/// <summary>
/// Using PolicyRatingOrg's Core business logic and exposing it as an endpoint in this API
/// </summary>
namespace PolicyRatingOrg.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RateController : Controller
    {
        private readonly RatingEngine _ratingEngine;
        private readonly StringPolicySource _policySource;
        public RateController(RatingEngine ratingEngine, StringPolicySource policySource)
        {
            _ratingEngine = ratingEngine;
            _policySource = policySource;
        }

        [HttpGet]
        public decimal Rating()
        {
            _policySource.PolicyString = @"{""type"" : ""Auto"", ""make"" : ""BMW""}";
            _ratingEngine.Rate();
            return _ratingEngine.Rating;
        }

        [HttpPost()]
        public ActionResult<decimal> Rate([FromBody] string policy)
        {
            _policySource.PolicyString = policy;
            _ratingEngine.Rate();

            return _ratingEngine.Rating;
        }
    }
}