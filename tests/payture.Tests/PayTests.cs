using Moq.Protected;
using Moq;
using System.Net;
using Microsoft.Extensions.Logging;
using payture.Domain.Dtos.Pay;
using FluentAssertions;
using payture.Infrastructure.Infrastructure.Payture;
using Microsoft.Extensions.DependencyInjection;

namespace payture.Tests
{
    public class PayTests
    {
        private readonly IServiceProvider _serviceProvider;

        public PayTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddPaytureInfrastructure();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [Fact]
        public async void Valid_Params_Returns_Success()
        {
            // Arrange
            var apiProvider = _serviceProvider.GetRequiredService<IApiProvider>();

            var orderId = Guid.NewGuid().ToString();

            var payInfo = new PayInfo()
            {
                Amount = 100,
                EMonth = 12,
                EYear = 25,
                PAN = "5218851946955484",
                OrderId = orderId,
                SecureCode = 123,

            };

            var request = new PayApiRequest
            {
                Key = "Merchant",
                OrderId = orderId,
                Amount = 1000,
                PayInfo = payInfo.ToString(),
            };

            // Act
            var response = await apiProvider.PayAsync(request, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Success.Should().BeTrue();
            response.ErrorCode.Should().BeNull();

        }

        [Fact]
        public async void Wrong_Expire_Date_Returns_Failure()
        {
            // Arrange
            var apiProvider = _serviceProvider.GetRequiredService<IApiProvider>();

            var orderId = Guid.NewGuid().ToString();

            var payInfo = new PayInfo()
            {
                Amount = 100,
                EMonth = 9,
                EYear = 11,
                PAN = "4400000000000008",
                OrderId = orderId,
                SecureCode = 521,

            };

            var request = new PayApiRequest
            {
                Key = "Merchant",
                OrderId = orderId,
                Amount = 1000,
                PayInfo = payInfo.ToString(),
            };

            // Act
            var response = await apiProvider.PayAsync(request, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Success.Should().BeFalse();
            response.ErrorCode.Should().Be("WRONG_EXPIRE_DATE");

        }

    }
}