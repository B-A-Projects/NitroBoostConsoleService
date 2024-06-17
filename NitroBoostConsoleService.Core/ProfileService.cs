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
        var getResponse = await SendRequest(HttpMethod.Get, $"{_configuration.Audience}users-by-email/{email}");
        if (!getResponse.IsSuccessStatusCode)
            return;
        
        Profile profile = JsonSerializer.Deserialize<Profile>(await getResponse.Content.ReadAsStringAsync());
        await SendRequest(HttpMethod.Delete, $"{_configuration.Audience}/users/{profile.UserId}");
        await _service.DeleteUser(email);
    }

    private async Task<HttpResponseMessage> SendRequest(HttpMethod method, string endpoint, string? body = null)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(method, endpoint);
        request.Headers.Add("Authorization", _token );
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