namespace RoadBoM.Web.Exceptions
{
    public class GenericException : Exception
    {
        public string ErrorCode { get; private set; }

        public GenericException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
