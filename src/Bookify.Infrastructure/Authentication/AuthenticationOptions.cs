namespace Bookify.Infrastructure.Authentication;

public sealed class AuthenticationOptions
{
    public required string Audience { get; init; }
    public required string MetadataUrl { get; init; }
    public bool RequireHttpsMetadata { get; init; }
    public required string Issuer { get; set; }
}