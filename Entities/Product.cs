namespace furniro_server.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Product : BaseEntity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(512)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(512)]
        public string ShortDescription { get; set; }

        [Required]
        [MinLength(32)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Discount { get; set; }

        [Required]
        [MinLength(0)]
        public int Quantity { get; set; }

        public bool IsNew { get; set; } = false;

        [Required]
        public string CoverPhotoURI { get; set; }
 
        public string[] AdditionalPhotosURIs { get; set; }

        // public HashSet<SizeOption> Sizes { get; set; }

        public string[] Colors { get; set; }
 

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public HashSet<Review> Reviews { get; set; }

        public HashSet<OrderProduct> OrderProducts { get; set; }
    }
}