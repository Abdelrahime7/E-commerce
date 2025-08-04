using Application.Interfaces.Iservices;
using Infrastructure.Payment.Strip;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace Infrastructure.Services.PyamentService
{
    public class StripePaymentService : IPaymentService
    {
       
        
            private readonly StripeSettings _settings;

            public  StripePaymentService(IOptions<StripeSettings> options)
            {
                _settings = options.Value;
                StripeConfiguration.ApiKey = _settings.SecretKey;
            }

            public async Task<string> CreateCheckoutSessionAsync(decimal amount, string currency)
            {
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

                var service = new SessionService();
                var session = await service.CreateAsync(options);
                return session.Url;
            }
        }

    
}
