namespace payture.Domain.Dtos.Pay
{
    public class CustomFieldsModel
    {
        public string? IP { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            var keyValues = new List<string>();

            if (!string.IsNullOrEmpty(IP))
            {
                keyValues.Add($"IP={IP}");
            }

            if (!string.IsNullOrEmpty(Description))
            {
                keyValues.Add($"Description={Description}");
            }

            return string.Join(";", keyValues);
        }
    }

}
