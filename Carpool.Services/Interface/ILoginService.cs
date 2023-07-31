using CarPool.Data;
using CarPool.Models;
namespace Carpool.Services.Interaface
{
    public interface ILoginService
    {
        Task<RegistrationResponse> Register(Credentials signUp);
        Task<CredentialsResponse> SignIn(Credentials signin);
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string hashedPassword);
    }
}
