namespace payture.Application.Commands
{
    public class PayCommand
    {
        public string Key { get; set; }
        public string OrderId { get; set; }
        public int Amount { get; set; }
        public string? PaytureId { get; set; }
        public string? CustomerKey { get; set; }
        public string? CustomFields { get; set; }
        public string? Cheque { get; set; }
        public string PAN { get; set; }
        public int EMonth { get; set; }
        public int EYear { get; set; }
        public int? SecureCode { get; set; }
        public string? CardHolder { get; set; }
        public string? IP { get; set; }
        public string? Description { get; set; }
    }
}
