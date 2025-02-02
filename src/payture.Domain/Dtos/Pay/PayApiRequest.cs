namespace payture.Domain.Dtos.Pay
{
    public class PayApiRequest
    {
        public string Key { get; set; }
        public string OrderId { get; set; }
        public int Amount { get; set; }
        public string PayInfo { get; set; }
        public string? PaytureId { get; set; }
        public string? CustomerKey { get; set; }
        public string? CustomFields { get; set; }
        public string? Cheque { get; set; }

    }
}
