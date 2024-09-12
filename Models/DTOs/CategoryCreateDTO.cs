using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniro_server.Models.DTOs
{
    public class CategoryCreateDTO
    {
        public required string Name { get; set; }
        public required string CoverPhoto { get; set; }

    }
}