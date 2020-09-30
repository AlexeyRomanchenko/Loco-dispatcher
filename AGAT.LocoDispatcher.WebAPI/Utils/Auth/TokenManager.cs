using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Permissions;
using System.Text;
using System.Web;

namespace AGAT.LocoDispatcher.WebAPI.Utils.Auth
{
    public class TokenManager
    {
        private static string Secret = Guid.NewGuid().ToString();
        
        public static string GenerateToken(string username)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)              
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);

            return handler.WriteToken(token);
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(token);
                if(jwtSecurityToken is null)
                {
                    return null;
                }
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
                TokenValidationParameters parameters = new TokenValidationParameters 
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = securityKey
                };
                SecurityToken securityToken;
                ClaimsPrincipal claimsPrincipal = handler.ValidateToken(token, parameters, out securityToken);
                return claimsPrincipal;
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ValidateToken(string token)
        {
            try
            {
                ClaimsPrincipal principal = GetPrincipal(token);
                if (principal is null)
                {
                    return null;
                }
                ClaimsIdentity identity = null;
                try
                {
                    identity = (ClaimsIdentity)principal.Identity;
                }
                catch (NullReferenceException)
                {
                    return null;
                }
                Claim claim = identity.FindFirst(ClaimTypes.Name);
                return claim.Value;
            }
            catch (Exception)
            {
                throw;
            }          
        }

    }
}