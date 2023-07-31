using System.ComponentModel.DataAnnotations;

namespace CarPool.Data
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string PasswordHash { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
