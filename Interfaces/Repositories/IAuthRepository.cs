using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using furniro_server.Models.DTOs.UserDtos;
using furniro_server.Models.Entities;

namespace furniro_server.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(AddUserDto addUser);
        Task<ServiceResponse<string>> Login(AddUserDto addUser);
        Task<bool> UserExists(AddUserDto addUser);
    }
}