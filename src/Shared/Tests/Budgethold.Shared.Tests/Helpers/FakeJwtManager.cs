namespace Budgethold.Shared.Tests.Helpers;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

public class FakeJwtManager
{
    public static string Issuer { get; } = "https://dev-5mqvwu3nmss680c7.eu.auth0.com/";
    public static string Audience { get; } = "https://localhost:7276";
    public static SecurityKey SecurityKey { get; }
    private static SigningCredentials SigningCredentials { get; }

    private static readonly JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
    private const int Key = 2048;

    static FakeJwtManager()
    {
        SecurityKey = new RsaSecurityKey(new RSACryptoServiceProvider(Key));
        SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.RsaSha256);
    }

    public static string GenerateJwtToken(IEnumerable<Claim> claims) => TokenHandler.WriteToken(new JwtSecurityToken(Issuer, Audience, claims, null, DateTime.UtcNow.AddMinutes(10), SigningCredentials));
}
