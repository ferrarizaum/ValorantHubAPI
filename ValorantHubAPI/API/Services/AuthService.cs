﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ValorantHubAPI.Data.Context;
using ValorantHubAPI.Data.Entities;
using static ValorantHubAPI.API.Services.AuthService;

namespace ValorantHubAPI.API.Services
{
    public interface IAuthService
    {
        LoginResponse Login(UserEntity model);
        string GenerateJwtToken(UserEntity user);
    }

    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context,
                            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public LoginResponse Login(UserEntity model)
        {
            var user = _context.Users.FirstOrDefault(u => u.userName == model.userName && u.password == model.password);

            if (user == null)
            {
                return null;
            }

            var token = GenerateJwtToken(user);

            return new LoginResponse
            {
                token = token,
                userName = user.userName
            };
        }

        public string GenerateJwtToken(UserEntity user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.userName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-very-secure-secret-key-of-at-least-32-characters-long"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims:claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public class LoginResponse
        {
            public string token { get; set; }
            public string userName { get; set; }
        }
    }
}



