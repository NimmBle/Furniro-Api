using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using furniro_server.Models.Entities;

namespace furniro_server.Models.DTOs.ProductDtos
{
    public class GetProductDto
    {
        public required string Name { get; set; }
        public required int CategoryId { get; set; }
        public required string ShortDescription { get; set; }
        public required string LongDescription { get; set; }
        public required decimal Price { get; set; }
        public int Discount { get; set; } = 0;
        public required int Quantity { get; set; }
        public bool IsNew { get; set; } = false;
        public required string CoverPhoto { get; set; }
        public List<string> AdditionalPhotos { get; set; } = new();
        public Sizes[] Sizes { get; set; }
        public List<string> Colors { get; set; } = new();
    }
}