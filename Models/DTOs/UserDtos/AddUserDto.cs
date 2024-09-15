using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniro_server.Models.DTOs.UserDtos
{
    public class AddUserDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}