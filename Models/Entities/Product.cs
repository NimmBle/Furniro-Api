namespace furniro_server.Models.Entities
{
    public class Product : BaseModel
    {
        public required string Name { get; set; }
        public required int CategoryId { get; set; }
        public Category Category { get; set; }
        public required string ShortDescription { get; set; }
        public required string LongDescription { get; set; }
        public required decimal Price { get; set; }
        public int Discount { get; set; } = 0;
        public required int Quantity { get; set; }
        public bool IsNew { get; set; } = false;
        public required string CoverPhoto { get; set; }
        public List<string> AdditionalPhotos { get; set; } = [];
        public List<string> Sizes { get; set; } = [];
        public List<string> Colors { get; set; } = [];
    }
}