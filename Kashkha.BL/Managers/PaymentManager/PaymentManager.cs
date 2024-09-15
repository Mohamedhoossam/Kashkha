using Kashkha.DAL;
using Stripe;
using Stripe.Checkout;

public class PaymentManager
{
    private readonly IOrderRepository _orderRepository;
    public PaymentManager(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
        
    }


    public async Task<Session> CreateCheckoutSessionAsync(int orderId, int userId)
    {
        var order = _orderRepository.GetOrderById(orderId, userId);
        var lineItems = new List<SessionLineItemOptions>();

        
            lineItems.Add(new SessionLineItemOptions
        {
            PriceData = new SessionLineItemPriceDataOptions
            {
                UnitAmount = (long)(order.TotalPrice * 100), 
                Currency = "usd",
                //ProductData = new SessionLineItemPriceDataProductDataOptions
                //{
                //    Name =order.Id,
                //},
            },
            //Quantity = order.,
        });
    

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