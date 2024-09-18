namespace furniro_server.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order : BaseEntity
    {
        [Required]
        public HashSet<OrderProduct> OrderProducts { get; set; }

        [Required]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        public Guid AddressId { get; set; }
        public FullAddress Address { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(1024)]
        public string AdditionalInformation { get; set; }
    }
}