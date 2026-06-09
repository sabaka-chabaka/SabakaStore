namespace SabakaStore.API.Infrastructure.Jwt;

public class JwtOptions
{
    public const string SectionName = "JwtOptions";

    public string SecretKey { get; init; } = string.Empty;
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public int ExpiresHours { get; init; } = 24;
}
