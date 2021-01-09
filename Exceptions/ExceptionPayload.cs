namespace LocadoraAspNet.Exceptions
{
    public class ExceptionPayload
    {
        public ExceptionPayload(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; set; }
    }
}