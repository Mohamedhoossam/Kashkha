using Kashkha.DAL;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PaymentManager _paymentManager;

    public PaymentController(PaymentManager paymentManager)
    {
        _paymentManager = paymentManager;
    }

    [HttpPost("create-checkout-session")]
    public async Task<IActionResult> CreateCheckoutSession(Order order, decimal totalPrice)
    {
        var session = await _paymentManager.CreateCheckoutSessionAsync(order, totalPrice);
        return Ok(new { SessionId = session.Id });
    }
}