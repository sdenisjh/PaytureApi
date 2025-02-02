namespace payture.Domain.Dtos.GetState
{
    public class GetStateApiResponse
    {
        public bool Success { get; set; }
        public string OrderId { get; set; }
        public bool Forwarded { get; set; }
        public string? State { get; set; }
        public string? MerchantContract { get; set; }
        public string? FinalTerminal { get; set; }
        public int? Amount { get; set; }
        public string? RRN { get; set; }
        public object? AddInfo { get; set; }
        public string? ErrCode { get; set; }
        public string RawResponse { get; set; }
    }
}
