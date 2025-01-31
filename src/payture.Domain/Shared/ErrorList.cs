namespace payture.Domain.Shared
{
    public class ErrorList : IEnumerable<Error>
    {
        public readonly List<Error> _errors;

        public ErrorList(IEnumerable<Error> errors)
        {
            _errors = errors.ToList();
        }
        public IEnumerator<Error> GetEnumerator()
        {
            return _errors.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static implicit operator ErrorList(List<Error> errors) => new(errors);

        public static implicit operator ErrorList(Error error) => new([error]);
    }
}
