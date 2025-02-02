using CSharpFunctionalExtensions;
using payture.Application.Commands;
using payture.Domain.Dtos.Pay;
using payture.Domain.Shared;

namespace payture.Application
{
    public interface IPaytureService
    {
        Task<Result<PayApiResponse, ErrorList>> PayAsync(PayCommand request, CancellationToken cancellation);
    }
}