using Microsoft.Extensions.Configuration;
using SacredBond.Common.Configs;
using SacredBond.Core.Domain;
using Stripe;

namespace SacredBond.Core.Financial
{
    public class FinancialService : IFinancialService
    {
        private readonly IConfiguration _configuration;
        public FinancialService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Tuple<string, string> CreateSubscription(
            string cardNumber,
            int month,
            int year,
            string cvc,
            string firstName,
            string lastName,
            string email)
        {
            StripeConfiguration.ApiKey = _configuration[StripeConfigs.Stripe_ApiKey];
            var options = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Number = cardNumber,
                    ExpMonth = month.ToString(),
                    ExpYear = year.ToString(),
                    Cvc = cvc,
                },
            };
            var service = new TokenService();

            Token stripeToken = service.Create(options);
            var customerService = new CustomerService();
            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email = email,
                Name = $"{firstName} {lastName}",
                Source = stripeToken.Id,
            });


            var subscriptionService = new SubscriptionService();
            var subscription = subscriptionService.Create(new SubscriptionCreateOptions
            {
                Customer = customer.Id,
                Items = new List<SubscriptionItemOptions>
                {
                    new SubscriptionItemOptions
                    {
                        Price = _configuration[StripeConfigs.Stripe_SubscriptionItemOptionPriceId]
                    }
                },
                PaymentSettings = new SubscriptionPaymentSettingsOptions
                {
                    PaymentMethodTypes = new List<string>
                    {
                        "card",
                    },
                },
            });
            return new Tuple<string, string>(customer.Id, subscription.Id);
        }

        public bool IsSubscriptionActive(string subscriptionId)
        {
            if (string.IsNullOrEmpty(subscriptionId)) 
                return false; 

            StripeConfiguration.ApiKey = _configuration[StripeConfigs.Stripe_ApiKey];
            var subscriptionService = new SubscriptionService();
            var subscription = subscriptionService.Get(subscriptionId);
            if (subscription == null)
                throw new Exception($"Unable to find stripe Subscription.");
             
            return subscription.Status == Stripe.SubscriptionStatuses.Active;
        }


        public string UpdateSubscription(
            string cardNumber,
            int month,
            int year,
            string cvc,
            string stripeCustomerId)
        {
            string result = "success";
            string customerId = stripeCustomerId;
            string subscriptionPlanId = _configuration[StripeConfigs.Stripe_SubscriptionItemOptionPriceId];

            var paymentMethodService = new PaymentMethodService();
            var customerService = new CustomerService();

            try
            {
                // Create a new payment method using the payment information
                var paymentMethodCreateOptions = new PaymentMethodCreateOptions
                {
                    Type = "card",
                    Card = new PaymentMethodCardOptions
                    {
                        Number = cardNumber, // Replace with the card number
                        ExpMonth = month, // Replace with the expiration month
                        ExpYear = year, // Replace with the expiration year
                        Cvc = cvc // Replace with the CVC
                    }
                };

                var paymentMethod = paymentMethodService.Create(paymentMethodCreateOptions);

                // Attach the payment method to the customer
                var attachOptions = new PaymentMethodAttachOptions
                {
                    Customer = customerId
                };
                paymentMethodService.Attach(paymentMethod.Id, attachOptions);

                // Update customer's default payment method
                var customerUpdateOptions = new CustomerUpdateOptions
                {
                    InvoiceSettings = new CustomerInvoiceSettingsOptions
                    {
                        DefaultPaymentMethod = paymentMethod.Id
                    }
                };
                var updatedCustomer = customerService.Update(customerId, customerUpdateOptions);

                var subscriptionOptions = new SubscriptionCreateOptions
                {
                    Customer = customerId,
                    Items = new List<SubscriptionItemOptions>
                {
                    new SubscriptionItemOptions
                    {
                        Plan = subscriptionPlanId
                    }
                }
                };

                // Create the subscription using the updated default payment method
                var subscriptionService = new SubscriptionService();
                Subscription subscription = subscriptionService.Create(subscriptionOptions);
                //Console.WriteLine("Subscription created successfully with updated payment method.");
            }
            catch (StripeException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                result = e.Message;
            }
            return result;
        }
    }


    public interface IFinancialService
    {
        Tuple<string, string> CreateSubscription(
            string cardNumber,
            int month,
            int year,
            string cvc,
            string firstName,
            string lastName,
            string email);

        bool IsSubscriptionActive(string subscriptionId);

        string UpdateSubscription(
            string cardNumber,
            int month,
            int year,
            string cvc,
            string stripeCustomerId);
    }
}
