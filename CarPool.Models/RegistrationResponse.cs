using CarPool.Data;
namespace CarPool.Models
{
    public class RegistrationResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public User User { get; set; }
    }
}
