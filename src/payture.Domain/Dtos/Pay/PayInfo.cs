namespace payture.Domain.Dtos.Pay
{
    public class PayInfo
    {
        public string PAN { get; set; }
        public int EMonth { get; set; }
        public int EYear { get; set; }
        public string OrderId { get; set; }
        public int Amount { get; set; }
        public int? SecureCode { get; set; }
        public string? CardHolder { get; set; }

        public override string ToString()
        {
            var keyValues = new List<string>
            {
                $"PAN={PAN}",
                $"EMonth={EMonth}",
                $"EYear={EYear}",
                $"OrderId={OrderId}",
                $"Amount={Amount}"
            };

            if (SecureCode.HasValue)
            {
                keyValues.Add($"SecureCode={SecureCode}");
            }

            if (!string.IsNullOrEmpty(CardHolder))
            {
                keyValues.Add($"CardHolder={CardHolder}");
            }

            return string.Join(";", keyValues);
        }
    }

}
