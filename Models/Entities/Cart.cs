using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniro_server.Models.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public HashSet<ProductCart> ProductCart { get; set; }
    }
}