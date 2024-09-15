namespace furniro_server.Models.DTOs
{
    using furniro_server.Models.Entities;

    public class GetCategoryDto
    {

        public required string Name { get; set; }
        public required string CoverPhoto { get; set; }

    }
}