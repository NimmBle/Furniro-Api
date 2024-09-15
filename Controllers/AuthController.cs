using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using furniro_server.Interfaces.Repositories;
using furniro_server.Models.DTOs.UserDtos;
using furniro_server.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace furniro_server.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepo = authRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(AddUserDto addUser) {
            ServiceResponse<int> serviceResponse = await _authRepo.Register(addUser);
            if (serviceResponse.Success == false) {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AddUserDto adduser) {
            ServiceResponse<string> serviceResponse = await _authRepo.Login(adduser);
            if (!serviceResponse.Success) {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }


    }
}