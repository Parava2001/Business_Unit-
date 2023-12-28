namespace businessUnit.Model
{
    public class ApiResponse // general API Response
    {
        // These are the general API responses
        public string Code { get; set; }

        public string Message { get; set; }

        public object? ResponseData { get; set; }
    }

    public enum ResponseType
    {
        Success,
        NotFound,
        Failure
    }
}
