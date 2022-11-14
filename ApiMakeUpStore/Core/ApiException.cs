namespace ApiMakeUpStore.Core
{
    public class ApiException : Exception
    {
        public int ErrorCode { get; }

        public ApiException(int? errorCode, string? message = null) : base(message)
        {
            ErrorCode = errorCode ?? 400;
        }

    }
}
