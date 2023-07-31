using CarPool.Data;
using Carpool.Services.Interface;
using Carpool.Services.Interaface;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using CarPool.Models;

namespace Carpool.Services
{
    public class LoginService : ILoginService
    {
        IUserDetailsService _userDetailsService;
        private readonly IConfiguration _configuration;
        public LoginService(IUserDetailsService userDetailsService, IConfiguration configuration)
        {
            _userDetailsService = userDetailsService;
            _configuration = configuration;
        }
        public string GetNameByEmail(string email)
        {
            var parts = email.Split("@");
            if (parts.Length >= 2)
                return parts[0];
            return string.Empty;
        }
        public async Task<RegistrationResponse> Register(Credentials credentials)
        {
            try
            {
                if (_userDetailsService.IsUserExistByEmail(credentials.Email))
                {
                    return new RegistrationResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "User already exists."
                    };
                }

                string passwordHash = HashPassword(credentials.Password);
                var newUser = new User
                {
                    Email = credentials.Email,
                    PasswordHash = passwordHash,
                    FirstName = GetNameByEmail(credentials.Email),
                    UserId = Guid.NewGuid().ToString(),
                    LastName = ""
                };

                User addedUser = await _userDetailsService.AddUser(newUser);

                if (addedUser == null)
                {
                    return new RegistrationResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "Failed to create user."
                    };
                }

                return new RegistrationResponse
                {
                    IsSuccess = true,
                    User = addedUser
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Register: {ex.Message}");
                return new RegistrationResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "An error occurred during registration."
                };
            }
        }


        public string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
        public bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            string enteredPasswordHash = HashPassword(enteredPassword);
            //use equals method for strings comparison
            return hashedPassword.Equals(enteredPasswordHash, StringComparison.Ordinal);
        }

        public string GenerateJwtToken(string userId)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, userId)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<CredentialsResponse> SignIn(Credentials credentials)
        {
            try
            {
                User user = await _userDetailsService.GetUserDetailsByEmail(credentials.Email);
                CredentialsResponse credentialsResponse = new CredentialsResponse();
                if (user == null)
                {
                    credentialsResponse.UserId = null;

                    return credentialsResponse;
                }
                credentialsResponse = new CredentialsResponse()
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                if (VerifyPassword(credentials.Password, user.PasswordHash))
                {
                    if (credentialsResponse.UserId != null)
                    {
                        credentialsResponse.JWTToken = GenerateJwtToken(credentialsResponse.UserId);
                        return credentialsResponse;
                    }
                }
                credentialsResponse.JWTToken = "";
                return credentialsResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Register: {ex.Message}");
                throw;
            }
        }
    }
}
