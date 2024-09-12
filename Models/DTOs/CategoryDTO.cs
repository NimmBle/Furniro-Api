using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using furniro_server.Models.Entities;

namespace furniro_server.Models.DTOs
{
    public class CategoryDTO
    {

        public required string Name { get; set; }
        public required string CoverPhoto { get; set; }

        public ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}