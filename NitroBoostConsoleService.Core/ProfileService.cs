using System.Text.Json;
using System.Text.Json.Serialization;
using NitroBoostConsoleService.Shared.Configuration;
using NitroBoostConsoleService.Shared.Dto;
using NitroBoostConsoleService.Shared.Interface.Service;

namespace NitroBoostConsoleService.Core;

public class ProfileService : IProfileService
{
    private IUserService _service;
    private AuthenticationConfiguration _configuration;
    private string _token;

    public ProfileService(IUserService service, AuthenticationConfiguration configuration, string token)
    {
        _service = service;
        _configuration = configuration;
        _token = token;
    }

    public async Task DeleteUserInformation(string email)
    {
        var getResponse = await SendRequest(HttpMethod.Get, $"{_configuration.Audience}users-by-email?email={email}", new Dictionary<string, string>()
        {
            {"Accept", "application/json"},
            {"Authorization", _token}
        });
        if (!getResponse.IsSuccessStatusCode)
            return;

        var profile = JsonSerializer.Deserialize<List<Profile>>(await getResponse.Content.ReadAsStringAsync());
        if (profile.Count == 0)
            return;
        
        var deleteResponse = await SendRequest(HttpMethod.Delete, $"{_configuration.Audience}users/{profile[0].UserId}", new Dictionary<string, string>()
        {
            {"Authorization", _token}
        });
        if (deleteResponse.IsSuccessStatusCode)
            await _service.DeleteUser(email);
    }

    private async Task<HttpResponseMessage> SendRequest(HttpMethod method, string endpoint, Dictionary<string, string>? headers = null, string? body = null)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(method, endpoint);
        if (headers == null) return await client.SendAsync(request);
        foreach (var header in headers)
        {
            request.Headers.Add(header.Key, header.Value);
        }
        return await client.SendAsync(request);
    }
}

internal class Profile
{
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }
    
    [JsonPropertyName("given_name")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("family_name")]
    public string LastName { get; set; }
    
    [JsonPropertyName("name")]
    public string FullName { get; set; }
    
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; }
    
    [JsonPropertyName("picture")]
    public string Picture { get; set; }
}