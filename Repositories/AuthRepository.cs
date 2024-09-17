namespace furniro_server.Repositories
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using AutoMapper;
    using furniro_server.Data;
    using furniro_server.Interfaces.Repositories;
    using furniro_server.Models.DTOs.UserDtos;
    using furniro_server.Models.Entities;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;

    public class AuthRepository : IAuthRepository
    {
        private readonly FurniroContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthRepository(FurniroContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
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
                serviceResponse.Data = CreateToken(user);
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

        private string CreateToken(User user) {

            List<Claim> claims = new() 
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };
            byte[] secretAsByteArray = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            SymmetricSecurityKey key = new(secretAsByteArray);
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256Signature);
            SecurityTokenDescriptor tokenDescriptor = new() {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}