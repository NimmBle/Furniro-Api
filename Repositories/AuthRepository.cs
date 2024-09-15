namespace furniro_server.Repositories
{
    using System.Security.Cryptography;
    using System.Text;
    using AutoMapper;
    using furniro_server.Data;
    using furniro_server.Interfaces.Repositories;
    using furniro_server.Models.DTOs.UserDtos;
    using furniro_server.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AuthRepository : IAuthRepository
    {
        private readonly FurniroContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(FurniroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<int>> Register(AddUserDto addUser)
        {
            ServiceResponse<int> serviceResponse = new();
            if (await UserExists(addUser)) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Username is already taken!";
                return serviceResponse;
            }
            else 
            {
                User user = _mapper.Map<User>(addUser);
                CreatePasswordHash(addUser, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                serviceResponse.Data = user.Id;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<string>> Login(AddUserDto addUser)
        {
            ServiceResponse<string> serviceResponse = new();
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == addUser.Username.ToLower());
            if (user == null) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User does not exist!";
            }
            else if (!VerifyPasswordHash(addUser.Password, user.PasswordHash, user.PasswordSalt)) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Wrong Password!";
            }
            else 
            {
                serviceResponse.Data = user.Id.ToString();
            }
            return serviceResponse;
        }

        public async Task<bool> UserExists(AddUserDto addUser)
        {
            if (await _context.Users.AnyAsync(u => u.Username.ToLower() == addUser.Username.ToLower()))
                return true;
            else
                return false;
        }


        private void CreatePasswordHash(AddUserDto addUser, out byte[] passwordHash, out byte[] passwordSalt) {

            using (var hmac = new HMACSHA256()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(addUser.Password));
            }
        }
        
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) {
            using (var hmac = new HMACSHA256(passwordSalt)) 
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++) 
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }
    }
}