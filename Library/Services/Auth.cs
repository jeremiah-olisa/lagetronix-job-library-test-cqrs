using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAuth
    {
        bool CheckPassword(string plainPassword, string encrypedPassword);
        string GenerateJWT(string userId, string isAdmin);
        string HashPassword(string plainPassword);
        bool ValidateToken(string authToken);
    }

    public class Auth : IAuth
    {
        private static string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        
        public bool CheckPassword(string plainPassword, string encrypedPassword)
        {
            return encrypedPassword == this.HashPassword(plainPassword);
        }

        public string GenerateJWT(string userId, string isAdmin)
        {
            // encryption key

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var secToken = new JwtSecurityToken(
                signingCredentials: credentials,
                issuer: "Jeremiah",
                audience: "Jeremiah",
                claims: new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sid, userId),
                    new Claim("isAdmin", isAdmin)
                },
                expires: DateTime.UtcNow.AddDays(1));

            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }

        public string HashPassword(string plainPassword)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(plainPassword);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);

            return true;
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,  
                ValidIssuer = "Jeremiah",
                ValidAudience = "Jeremiah",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };
        }
    }
}
