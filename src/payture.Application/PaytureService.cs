using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using payture.Application.Commands;
using payture.Domain.Dtos.Pay;
using payture.Domain.Shared;
using payture.Infrastructure.Infrastructure.Payture;

namespace payture.Application
{
    public class PaytureService : IPaytureService
    {
        private readonly ILogger<PaytureService> _logger;
        private readonly IApiProvider _apiProvider;

        public PaytureService(IApiProvider apiProvider, ILogger<PaytureService> logger)
        {
            _logger = logger;
            _apiProvider = apiProvider;
        }

        public async Task<Result<PayApiResponse, ErrorList>> PayAsync(PayCommand command, CancellationToken cancellation)
        {
            _logger.LogInformation("Starting Pay request for OrderId: {OrderId}", command.OrderId);

            var payInfo = new PayInfo()
            {
                PAN = command.PAN,
                Amount = command.Amount,
                EMonth = command.EMonth,
                EYear = command.EYear,
                OrderId = command.OrderId,
                SecureCode = command.SecureCode,
                CardHolder = command.CardHolder,
            };

            var customFileds = new CustomFieldsModel()
            {
                IP = command.IP,
                Description = command.Description,
            };

            var apiRequest = new PayApiRequest()
            {
                Key = command.Key,
                OrderId = command.OrderId,
                Amount = command.Amount,
                PayInfo = payInfo.ToString(),
                PaytureId = command.PaytureId,
                CustomerKey = command.CustomerKey,
                Cheque = command.Cheque,
                CustomFields = customFileds.ToString(),

            };

            var result = await _apiProvider.PayAsync(apiRequest, cancellation);
            if (result.Success == false)
            {
                return Errors.Payment.FailedOperation(result.ErrorCode).ToErrorList();
            }

            return result;

        }
    }
}
