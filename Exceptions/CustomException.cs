namespace Invoices.Exceptions
{
    [Serializable]
    public class CustomException : Exception
    {
        public CustomException(string code) {
            Code = code;
        }

        public string Code { get; set; }
    }
}
