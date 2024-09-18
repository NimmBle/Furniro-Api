namespace furniro_server.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Category : BaseEntity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        public string CoverPhotoURI { get; set; }

        public HashSet<Product> Products { get; set; }
    }
}