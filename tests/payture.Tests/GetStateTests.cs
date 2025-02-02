using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using payture.Domain.Dtos.GetState;
using payture.Infrastructure.Infrastructure.Payture;

namespace payture.Tests
{
    public class GetStateTests
    {
        private readonly ServiceProvider _serviceProvider;

        public GetStateTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddPaytureInfrastructure();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [Fact]
        public async void Success_Params_Returns_Success()
        {
            // Arrange
            var apiProvider = _serviceProvider.GetRequiredService<IApiProvider>();

            var request = new GetStateApiRequest()
            {
                Key = "Merchant",
                OrderId = "225483f5-e477-41aa-953a-4c6f25ca4585"
            };

            // Act
            var response = await apiProvider.GetStateAsync(request, CancellationToken.None);

            // Assert
            response.Success.Should().BeTrue();
            response.Forwarded.Should().BeFalse();
            response.State.Should().Be("Charged");
            response.Amount.Should().Be(1000);
            response.ErrCode.Should().BeNull();

        }

        [Fact]
        public async void Invalid_Params_Returns_NotFound()
        {
            // Arrange
            var apiProvider = _serviceProvider.GetRequiredService<IApiProvider>();

            var request = new GetStateApiRequest()
            {
                Key = "Merchant",
                OrderId = "3c250c5c-55fa-cef2-a999-3504aca4dfac"
            };

            // Act
            var response = await apiProvider.GetStateAsync(request, CancellationToken.None);

            // Assert
            response.Success.Should().BeFalse();
            response.Forwarded.Should().BeFalse();
            response.ErrCode.Should().Be("ORDER_NOT_FOUND");

        }

    }
}
