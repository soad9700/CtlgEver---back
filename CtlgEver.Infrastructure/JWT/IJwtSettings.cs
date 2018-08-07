namespace CtlgEver.Infrastructure.JWT
{
    public interface IJwtSettings
    {
        string Key {get; set;}
        int ExpiryDays {set; get;}
    }
}