using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using NitroBoostConsoleService.Shared.Configuration;

namespace NitroBoostConsoleService.Shared.Dto;

public static class TokenDto
{
    public static string RefreshUrl { private get; set; }
    public static AuthenticationConfiguration Configuration { private get; set; }

    private static string _tokenString;
    private static string _tokenStringCopy;
    private static string _tokenType = "Bearer";
    
    private static DateTime _createdDateTime;
    private static DateTime _expiredDateTime => _createdDateTime.AddMinutes(55);
    private static bool _IsUpdating = false;

    public static string GetToken()
    {
        if (_expiredDateTime >= DateTime.Now && !_IsUpdating)
            UpdateToken();
        else if (_IsUpdating)
            return $"{_tokenType} {_tokenStringCopy}";
        return $"{_tokenType} {_tokenString}";
    }
    
    private static void UpdateToken()
    {
        try
        {
            _IsUpdating = true;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, RefreshUrl);
            request.Headers.Add("content-type", "application/json");
            request.Content = JsonContent.Create(Configuration, typeof(AuthenticationConfiguration),
                MediaTypeHeaderValue.Parse("application/json"));

            var response = client.Send(request);
            if (response.IsSuccessStatusCode)
            {
                var body = JsonSerializer.Deserialize<TokenResponse>(response.Content.ToString());
                _tokenString = body.AccessToken;
                _tokenType = body.TokenType;
            }
            _createdDateTime = DateTime.Now;
        }
        finally
        {
            _IsUpdating = false;
            _tokenStringCopy = _tokenString;
        }
    }
}

internal class TokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
}