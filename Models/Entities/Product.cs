using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniro_server.Models.Entities
{
    public class Product : BaseModel
    {
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        public required string ShortDescription { get; set; }
        public required string LongDescription { get; set; }
        public required decimal Price { get; set; }
        public int Discount { get; set; }
        public required int Quantity { get; set; }
        public bool? IsNew { get; set; }
        public required string CoverPhoto { get; set; }
        public string[]? AdditionalPhotos { get; set; }
        public string[]? Sizes { get; set; }
        public string[]? Colors { get; set; }
    }
}