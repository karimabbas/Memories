using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Server.Data;
using Server.Dto;
using Server.Models;

namespace Server.Helpers
{
    public class JwtService
    {
        private readonly IConfiguration _config;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly DataContext _dataContext;

        public JwtService(IConfiguration configuration, TokenValidationParameters tokenValidationParameters, DataContext dataContext)
        {
            _config = configuration;
            _tokenValidationParameters = tokenValidationParameters;
            _dataContext = dataContext;
        }
        public TokenResponse GenerateToken(AppUser appUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]{
                    new Claim("Id",appUser.Id),
                    new Claim(JwtRegisteredClaimNames.Email,appUser.Email),
                    new Claim(JwtRegisteredClaimNames.Sub,appUser.Email),
                    new Claim(JwtRegisteredClaimNames.Iat , DateTime.UtcNow.ToUniversalTime().ToString())
                }),

                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = credentials,
            };
            //// Without descriptor
            // var Token = new JwtSecurityToken(
            //     _config["Jwt:Issuer"],
            //     _config["Jwt:Audience"],
            //     claims: claims,
            //     expires: DateTime.Now.AddMonths(2),
            //     signingCredentials: credentials);

            var Token = new JwtSecurityTokenHandler().CreateToken(descriptor);
            var AccessToken = new JwtSecurityTokenHandler().WriteToken(Token);


            var refreshToken = new RefreshToken()
            {
                JwtId = Token.Id,
                IsUsed = false,
                IsRevoked = false,
                UserId = appUser.Id,
                AddedDate = DateTime.UtcNow,
                ExpireDate = DateTime.UtcNow.AddMonths(7),
                Token = GenerateRefreshToken()
            };
            _dataContext.RefreshTokens.Add(refreshToken);
            _dataContext.SaveChanges();

            return new TokenResponse()
            {
                Token = AccessToken,
                RefreshToken = refreshToken,
                TokenExpiry = Token.ValidTo
            };

        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }


        public object VerifyTokenAndGenerate(TokenRequest tokenRequest)
        {
            var JwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var TokenValidationParameters = new TokenValidationParameters
            {
                ////For Development onlyyyyyyyy===>>>>>> RequireExpirationTime=false
                RequireExpirationTime = false,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = false,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidAudience = _config["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]))
            };

            try
            {
                TokenValidationParameters.ValidateLifetime = false;

                ///Validtion 1 ------ valdiation JWT token format
                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(tokenRequest.Token, TokenValidationParameters, out SecurityToken validatedToken);

                //Validation 2 ------- validate encryiption alg
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var res = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    if (res == false)
                    {
                        throw new SecurityTokenException("Invalid token");

                    }

                }

                //Validation 3 ---- validate expire date

                var UtcExpiryDate = long.Parse(principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expiryDate = UnixTimeStampToDateTime(UtcExpiryDate);
                DateTime dt1 = expiryDate;
                DateTime dt2 = DateTime.Now;
                int date = DateTime.Compare(dt1, dt2);

                if (date > 0)
                    return new ErrorMessage()
                    {
                        Message = "Token Has Not Yet Expired"
                    };

                //Validation 4 
                var storedToken = _dataContext.RefreshTokens.FirstOrDefault(x => x.Token == tokenRequest.RefreshToken);

                if (storedToken == null)
                    return new ErrorMessage()
                    {
                        Message = "Token Does Not Exist"
                    };

                //Validtion 5 
                if (storedToken.IsUsed)
                    return new ErrorMessage()
                    {
                        Message = "Token has been Used before"
                    };

                ///Validation 6 
                if (storedToken.IsRevoked)
                    return new ErrorMessage()
                    {
                        Message = "Token has been Revoked"
                    };

                ///Validtion 7
                var jti = principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
                if (storedToken.JwtId != jti)
                    return new ErrorMessage()
                    {
                        Message = "Token Does'nt Match"
                    };

                storedToken.IsUsed = true;
                _dataContext.RefreshTokens.Update(storedToken);
                _dataContext.SaveChanges();

                var DBuser = _dataContext.Users.Find(storedToken.UserId);
                var result = GenerateToken(DBuser);
                return new TokenResponse()
                {
                    Token = result.Token,
                    RefreshToken = result.RefreshToken,
                    TokenExpiry = result.TokenExpiry
                };

            }
            catch (System.Exception ex)
            {
                return new ErrorMessage()
                {
                    Message = ex.Message
                };

            }
        }

        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeVal = dateTimeVal.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTimeVal;
        }
    }
}