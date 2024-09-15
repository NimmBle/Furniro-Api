using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniro_server.Models.Entities
{
    public class User : BaseModel
    {
        public required string Username { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
    }
}