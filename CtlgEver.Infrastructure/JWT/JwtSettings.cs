namespace CtlgEver.Infrastructure.JWT
{
    public class JwtSettings : IJwtSettings
    {
        public string Key {get; set;} = "secret CtlgEver password";
        public int ExpiryDays {get; set;} = 1;
    }
}