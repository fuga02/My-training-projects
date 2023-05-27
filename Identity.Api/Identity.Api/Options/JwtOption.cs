namespace Identity.Api.Options;

public class JwtOption
{
    public string SignInKey { get; set;}
    public string ValidIssuer { get; set;}
    public string ValidAudience { get; set;}

    public int ExpiresInSecunds { get; set;}
}