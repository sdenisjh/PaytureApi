using payture.Application.Commands;

namespace payture.Web.Contracts
{
    public class GetStateRequest
    {
        public string Key { get; set; }
        public string OrderId { get; set; }

        public GetStateCommand ToCommand()
        {
            return new GetStateCommand { Key = Key, OrderId = OrderId };
        }
    }
}
