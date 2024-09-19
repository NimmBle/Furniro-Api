namespace furniro_server.DTOs.CategoryDTOs
{
    using System.ComponentModel.DataAnnotations;
    using furniro_server.Entities;

    public class AddCategoryDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string CoverPhotoURI { get; set; }

        public HashSet<Product> Products { get; set; }
    }
}