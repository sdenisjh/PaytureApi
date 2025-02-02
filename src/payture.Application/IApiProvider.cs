using payture.Domain.Dtos.GetState;
using payture.Domain.Dtos.Pay;

namespace payture.Infrastructure.Infrastructure.Payture
{
    public interface IApiProvider
    {
        Task<GetStateApiResponse> GetStateAsync(GetStateApiRequest request, CancellationToken cancellation);
        Task<PayApiResponse> PayAsync(PayApiRequest request, CancellationToken cancellation);
    }
}