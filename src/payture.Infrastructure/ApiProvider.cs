using Microsoft.Extensions.Logging;
using payture.Domain.Dtos.GetState;
using payture.Domain.Dtos.Pay;
using payture.Infrastructure.Infrastructure.Payture;
using System.Xml.Linq;

public class ApiProvider : IApiProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiProvider> _logger;

    public ApiProvider(HttpClient httpClient, ILogger<ApiProvider> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<GetStateApiResponse> GetStateAsync(GetStateApiRequest request, CancellationToken cancellation)
    {
        _logger.LogInformation("Starting Pay request for OrderId: {OrderId}", request.OrderId);

        var response = await _httpClient.GetAsync($"GetState?Key={request.Key}&OrderId={request.OrderId}");
        var responseString = await response.Content.ReadAsStringAsync();

        _logger.LogInformation("Pay response received: {Response}", responseString);

        return ParseGetStateResponse(responseString);

    }

    private GetStateApiResponse ParseGetStateResponse(string xml)
    {
        try
        {
            var doc = XDocument.Parse(xml);
            var root = doc.Root;

            if (root == null)
                throw new Exception("Invalid XML format");

            var success = root.Attribute("Success")?.Value == "True";
            var errCode = root.Attribute("ErrCode")?.Value;

            return new GetStateApiResponse
            {
                Success = success,
                OrderId = root.Attribute("OrderId")?.Value,
                Forwarded = root.Attribute("Forwarded")?.Value == "True",
                State = success ? root.Attribute("State")?.Value : null,
                MerchantContract = root.Attribute("MerchantContract")?.Value,
                FinalTerminal = success ? root.Attribute("FinalTerminal")?.Value : null,
                Amount = success && int.TryParse(root.Attribute("Amount")?.Value, out var amount) ? amount : null,
                RRN = success ? root.Attribute("RRN")?.Value : null,
                AddInfo = success ? root.Attribute("AddInfo")?.Value : null,
                ErrCode = success ? null : errCode,
                RawResponse = xml
            };
        }
        catch
        {
            return new GetStateApiResponse
            {
                Success = false,
                ErrCode = "XML_PARSE_ERROR",
                RawResponse = xml
            };
        }
    }


    public async Task<PayApiResponse> PayAsync(PayApiRequest request, CancellationToken cancellation)
    {
        _logger.LogInformation("Starting Pay request for OrderId: {OrderId}", request.OrderId);

        var parameters = new Dictionary<string, string>
        {
            { "Key", request.Key },
            { "OrderId", request.OrderId },
            { "Amount", request.Amount.ToString() },
            { "PayInfo", request.PayInfo }
        };

        AddCustomFields(parameters, "CustomFields", request.CustomFields);

        var content = new FormUrlEncodedContent(parameters);
        var response = await _httpClient.PostAsync("Pay", content);
        var responseString = await response.Content.ReadAsStringAsync();

        _logger.LogInformation("Pay response received: {Response}", responseString);

        return ParsePayResponse(responseString);
    }

    private void AddCustomFields(Dictionary<string, string> parameters, string key, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            parameters.Add(key, value);
        }
    }

    private PayApiResponse ParsePayResponse(string xml)
    {
        try
        {
            var doc = XDocument.Parse(xml);
            var success = doc.Root?.Attribute("Success")?.Value == "True";
            var errCode = doc.Root?.Attribute("ErrCode")?.Value;

            return new PayApiResponse
            {
                Success = success,
                ErrorCode = errCode,
                RawResponse = xml
            };
        }
        catch
        {
            return new PayApiResponse
            {
                Success = false,
                ErrorCode = "XML_PARSE_ERROR",
                RawResponse = xml
            };
        }
    }
}
