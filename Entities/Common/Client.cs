namespace furniro_server.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Client : 
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string CompanyName { get; set; }
    }
}