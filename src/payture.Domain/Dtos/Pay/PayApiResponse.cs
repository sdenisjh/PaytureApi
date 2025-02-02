namespace payture.Domain.Dtos.Pay
{
    public class PayApiResponse
    {
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public string RawResponse { get; set; }
    }
}
