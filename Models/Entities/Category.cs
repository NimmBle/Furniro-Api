using furniro_server.Models.Entities;

namespace furniro_server.Models
{
    public class Category : BaseModel
    {

        public required string Name { get; set; }
        public required string CoverPhoto { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}