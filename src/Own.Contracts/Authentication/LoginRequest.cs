namespace Own.Contracts.Authentication
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int MyProperty { get; set; }
    }
}