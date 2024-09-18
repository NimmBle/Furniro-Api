namespace furniro_server.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Feedback : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(256)]
        public string ClientName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(256)]
        public string Subject { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(2048)]
        public string Message { get; set; }
    }
}