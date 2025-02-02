using payture.Application.Commands;

namespace payture.Web.Contracts
{
    public class PayRequest
    {
        public string Key { get; set; }
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

        public PayCommand ToCommand(Guid orderId)
        {
            return new PayCommand()
            {
                Key = Key,
                Amount = Amount,
                OrderId = orderId.ToString(),
                PaytureId = PaytureId,
                CustomerKey = CustomerKey,
                CustomFields = CustomFields,
                Cheque = Cheque,
                PAN = PAN,
                EMonth = EMonth,
                EYear = EYear,
                SecureCode = SecureCode,
                CardHolder = CardHolder,
                IP = IP,
                Description = Description,

            };
        }

    }
}
