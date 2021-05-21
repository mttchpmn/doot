namespace Api.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Successful { get; set; } = true;
        public bool ErrorMessage { get; set; }
    }
}