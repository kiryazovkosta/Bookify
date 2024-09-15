using System.Net.Http.Json;
using Bookify.Application.Abstractions.Authentication;
using Bookify.Application.Users.LogInUser;
using Bookify.Domain.Abstractions;
using Bookify.Infrastructure.Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Bookify.Infrastructure.Authentication;

public class JwtService : IJwtService
{
    private static readonly Error AuthenticationFailed = new(
        "Keycloak.AuthenticationFailed",
        "Failed to acquire access token do to authentication failure");
    
    private readonly HttpClient _httpClient;
    private readonly KeycloakOptions _keycloakOptions;


    public JwtService(HttpClient httpClient, IOptions<KeycloakOptions> keycloakOptions)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _keycloakOptions = keycloakOptions.Value ?? throw new ArgumentNullException(nameof(keycloakOptions));
    }

    public async Task<Result<AccessTokenResponse>> GetAccessTokenAsync(
        string email, 
        string password, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            var authRequestParameters = new KeyValuePair<string, string>[]
            {
                new("client_id", _keycloakOptions.AuthClientId),
                new("client_secret", _keycloakOptions.AuthClientSecret),
                new("scope", "openid email"),
                new("grant_type", "password"),
                new("username", email),
                new("password", password)
            };

            var authorizationRequestContent = new FormUrlEncodedContent(authRequestParameters);

            var response = await _httpClient.PostAsync("", authorizationRequestContent, cancellationToken);

            response.EnsureSuccessStatusCode();

            var authorizationToken = await response.Content.ReadFromJsonAsync<AuthorizationToken>(cancellationToken);

            if (authorizationToken is null)
            {
                return Result.Failure<AccessTokenResponse>(AuthenticationFailed);
            }

            return new AccessTokenResponse(authorizationToken.AccessToken, authorizationToken.RefreshToken);
        }
        catch (HttpRequestException)
        {
            return Result.Failure<AccessTokenResponse>(AuthenticationFailed);
        }
    }
}