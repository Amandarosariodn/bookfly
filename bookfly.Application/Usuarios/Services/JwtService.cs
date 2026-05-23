using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using bookfly.Application.Usuarios.Services.Interfaces;
using bookfly.Domain.Usuarios.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace bookfly.Application.Usuarios.Services
{
    public class JwtService(IConfiguration configuration) : IJwtService
    {
        public string GerarToken(Usuario usuario)
        {
            string secretKey = configuration["Jwt:SecretKey"]
                ?? throw new InvalidOperationException("Jwt:SecretKey não configurada.");

            string issuer = configuration["Jwt:Issuer"]
                ?? throw new InvalidOperationException("Jwt:Issuer não configurado.");

            string audience = configuration["Jwt:Audience"]
                ?? throw new InvalidOperationException("Jwt:Audience não configurado.");

            string? expirationMinutesConfiguration = configuration["Jwt:ExpirationMinutes"];
            int expirationMinutes = int.TryParse(expirationMinutesConfiguration, out int parsedExpirationMinutes)
                ? parsedExpirationMinutes
                : 60;

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, usuario.Email),
                new(JwtRegisteredClaimNames.UniqueName, usuario.Username),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.NameIdentifier, usuario.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
