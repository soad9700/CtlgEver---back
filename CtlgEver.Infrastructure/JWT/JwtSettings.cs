namespace CtlgEver.Infrastructure.JWT
{
    public class JwtSettings : IJwtSettings
    {
        public string Key {get; set;}
        public int ExpiryDays {get; set;}
    }
}