using CSharpFunctionalExtensions;
using payture.Application.Commands;
using payture.Domain.Dtos.GetState;
using payture.Domain.Dtos.Pay;
using payture.Domain.Shared;

namespace payture.Application
{
    public interface IPaytureService
    {
        Task<Result<PayApiResponse, ErrorList>> PayAsync(PayCommand request, CancellationToken cancellation);
        Task<Result<GetStateApiResponse, ErrorList>> GetState(GetStateCommand command, CancellationToken cancellation);
    }
}