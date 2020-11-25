using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PolicyRatingOrg.WithSolidPrinciples;
using PolicyRatingOrg.WithSolidPrinciples.Infrastructure.Loggers;
using PolicyRatingOrg.WithSolidPrinciples.Infrastructure.PolicySources;
using ILogger = PolicyRatingOrg.WithSolidPrinciples.ILogger;

namespace PolicyRatingOrg.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<RatingEngine>();
            services.AddScoped<RaterFactory>();
            services.AddScoped<StringPolicySource>();
            services.AddScoped<IPolicySource, StringPolicySource>(sp => sp.GetRequiredService<StringPolicySource>());
            services.AddScoped<ILogger, NullLogger>();
            services.AddScoped<IPolicySerializer, JsonPolicySerializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
