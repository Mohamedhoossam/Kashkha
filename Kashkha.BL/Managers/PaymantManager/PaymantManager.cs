using Kashkha.DAL;
using Stripe;
using Stripe.Checkout;

public class PaymantManager
{
    public async Task<Session> CreateCheckoutSessionAsync(Order order, decimal totalPrice)
    {
        var lineItems = new List<SessionLineItemOptions>();

        foreach (var item in order.orderItems)
        {
            lineItems.Add(new SessionLineItemOptions
        {
            PriceData = new SessionLineItemPriceDataOptions
            {
                UnitAmount = (long)(item.Product.Price * 100), 
                Currency = "usd",
                ProductData = new SessionLineItemPriceDataProductDataOptions
                {
                    Name = item.Product.Name,
                },
            },
            Quantity = item.Quantity,
        });
    }

    var options = new SessionCreateOptions
    {
        PaymentMethodTypes = new List<string> { "card" },
        LineItems = lineItems,
        Mode = "payment",
        SuccessUrl = "https://localhost:5001/api/payment/success?orderId=" + order.Id,
        CancelUrl = "https://localhost:5001/api/payment/cancel?orderId=" + order.Id,
    };

    var service = new SessionService();
    return await service.CreateAsync(options);
}
}