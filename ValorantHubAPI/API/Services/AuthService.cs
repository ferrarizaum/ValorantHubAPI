using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ValorantHubAPI.Data.Context;
using ValorantHubAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ValorantHubAPI.API.Services
{
    public interface IAuthService
    {
        string Login(UserEntity model);
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

        [HttpPost]
        public string Login(UserEntity model)
        {
            var user = _context.Users.FirstOrDefault(u => u.userName == model.userName && u.password == model.password);
            Console.WriteLine("login");

            if (user == null)
            {
                return null;
            }

            // Create JWT token
            var token = GenerateJwtToken(user);
            Console.WriteLine(token.ToString());
            return token.ToString();
        }

        public string GenerateJwtToken(UserEntity user)
        {
            Console.WriteLine("entou");
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.userName),
            // Add more claims if needed
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-very-secure-secret-key-of-at-least-32-characters-long"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "your-issuer",
                audience: "your-audience",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}



