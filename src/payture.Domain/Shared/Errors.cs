namespace payture.Domain.Shared
{
    public static class Errors
    {
        public static class General
        {
            public static Error ValueIsInvalid(string? name = null)
            {
                var label = name ?? "value";
                return Error.Validation("value.is.invalid", $"{label} is invalid");
            }

            public static Error NotFound(Guid? id = null)
            {
                var forId = id == null ? "" : $"for id '{id}'";
                return Error.NotFound("record.not.found", $"record not found {forId}");
            }

            public static Error ValueIsRequired(string? name = null)
            {
                var label = name == null ? "" : " " + name + " ";
                return Error.Validation("length.is.invalid", $"invalid{label}");
            }

            public static Error AlreadyExists(string? name = null)
            {
                var label = name == null ? "" : " " + name + " ";
                return Error.Conflict("already.exists", $"invalid{label}");
            }
        }

        public static class Payment
        {
            public static Error FailedOperation(string? name = null)
            {
                return Error.Failure($"{name}", $"payment failed");
            }
        }

        public static class GetState
        {
            public static Error FailedOperation(string? name = null)
            {
                return Error.Failure($"{name}", $"get state operation failed");
            }
        }
    }

}
