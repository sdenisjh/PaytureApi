using Microsoft.AspNetCore.Mvc;
using payture.Application;
using payture.Domain.Dtos.Pay;
using payture.Web.Contracts;
using payture.Web.Shared;

namespace payture.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaytureService _paytureService;

        public PaymentController(IPaytureService paytureService)
        {
            _paytureService = paytureService;
        }

        [HttpPost("pay")]
        public async Task<IActionResult> Pay([FromBody] PayRequest request, CancellationToken cancellation)
        {
            var orderId = Guid.NewGuid();
            var command = request.ToCommand(orderId);

            var result = await _paytureService.PayAsync(command, cancellation);
            if (result.IsFailure)
            {
                return result.Error.ToResponse();
            }


            return Ok(result.Value);
        }

        //[HttpGet("state/{orderId}")]
        //public async Task<IActionResult> GetState(string orderId)
        //{
        //    var result = await _paytureService.GetStateAsync(orderId);
        //    return Ok(result);
        //}
    }
}
