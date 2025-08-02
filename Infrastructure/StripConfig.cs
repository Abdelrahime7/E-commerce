using Infrastructure.Payment.Strip;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Stripe;

namespace Infrastructure
{
    public static class StripConfig
    {
     
        public static void StripConfige(this WebApplicationBuilder builder) {

            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

        }
    }
}
