namespace Own.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Issuer { get; set; }

        // public string DefaultAuthenticateScheme { get; set; }

        // public string DefaultChallengeScheme { get; set; }

        public string Audience { get; set; }

        public int ExpiryMinutes { get; set; }

        // public int ClockSkew { get; set; }

        public string Secret { get; set; }
        public string SchemeName { get; set; }

        // public int MaxErrorTimes { get; set; }
    }
}