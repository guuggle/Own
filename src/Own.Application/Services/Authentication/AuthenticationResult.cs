using System;

namespace Own.Application.Services.Authentication
{
    public class AuthenticationResult
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}