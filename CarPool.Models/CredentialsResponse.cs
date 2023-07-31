namespace CarPool.Data
{
    public class CredentialsResponse
    {
        public string UserId { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Email { get; set; }
        public string JWTToken { get; set; }
    }
}
