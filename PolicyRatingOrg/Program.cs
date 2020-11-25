using PolicyRatingOrg.WithSolidPrinciples;
using System;

namespace PolicyRatingOrg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insurance Rating System Starting...");

            var engine = new WithoutSolidPrinciples.RatingEngine();
            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }

            Console.WriteLine("=======================================");

            var logger = new ConsoleLogger();

            var engineTwo = new RatingEngine(logger, 
                new FilePolicySource(),
                new JsonPolicySerializer(),
                new RaterFactory(logger));

            engineTwo.Rate();
            if (engineTwo.Rating > 0)
            {
                Console.WriteLine($"Rating: {engineTwo.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }
        }
    }
}
