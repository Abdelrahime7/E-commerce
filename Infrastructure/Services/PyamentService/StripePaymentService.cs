using Application.Interfaces.Iservices;
using Infrastructure.Payment.Strip;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace Infrastructure.Services.PyamentService
{
    public class StripePaymentService : IPaymentService
    {
       
        
            private readonly StripeSettings _settings;
            private readonly ILogger<StripePaymentService> _logger;

            public  StripePaymentService(IOptions<StripeSettings> options,
               ILogger<StripePaymentService> looger)
            {
               _logger = looger;
                _settings = options.Value;
                StripeConfiguration.ApiKey = _settings.SecretKey;
            }

            public async Task<string> CreateCheckoutSessionAsync(decimal amount, string currency)
            {
             _logger.LogInformation("Creating Stripe checkout session for amount: {Amount} {Currency}", amount, currency);
               var options = new SessionCreateOptions
               {
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = new List<SessionLineItemOptions>
                    {
                      new SessionLineItemOptions
                      {
                    PriceData = new SessionLineItemPriceDataOptions
                        {
                          UnitAmount = (long)(amount * 100), // Stripe expects cents
                          Currency = currency,
                          ProductData = new SessionLineItemPriceDataProductDataOptions
                          {
                            Name = "Cart Total"
                           }
                        },
                    Quantity = 1
                    }
                },
                    Mode = "payment",
                    SuccessUrl = "https://yourdomain.com/payment/success",
                    CancelUrl = "https://yourdomain.com/payment/cancel"
                };
            try
            {
                var service = new SessionService();
                var session = await service.CreateAsync(options);

                _logger.LogInformation("Stripe checkout session created successfully. Session URL: {SessionUrl}", session.Url);
                return session.Url;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create Stripe checkout session for amount: {Amount} {Currency}", amount, currency);
                throw;
            }


        }
        }

    
}
