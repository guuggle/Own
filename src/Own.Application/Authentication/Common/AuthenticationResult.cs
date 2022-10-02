using System;
using Own.Domain.Entites;

namespace Own.Application.Authentication.Common
{
    public class AuthenticationResult
    {
        public SysUser User { get; set; }
        public string? Token { get; set; }
    }
}