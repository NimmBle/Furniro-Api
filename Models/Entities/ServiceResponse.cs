namespace furniro_server.Models.Entities
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public string? Message { get; set; }
    }
}