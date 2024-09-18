namespace furniro_server.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class FullAddress : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(256)]
        public string Country { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(256)]
        public string City { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(512)]
        public string Address { get; set; }

        [Required]
        [MinLength(1000)]
        [MaxLength(9999)]
        public int PostalCode { get; set; }

        public HashSet<Order> Orders { get; set; }
    }
}