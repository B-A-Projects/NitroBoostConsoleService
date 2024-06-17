using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using NitroBoostConsoleService.Shared.Logging;

namespace NitroBoostConsoleService.Messaging;

public class TokenHelper
{
    private string _issuer { get; set; }
    private string _audience { get; set; }

    public TokenHelper(string issuer, string audience)
    {
        _issuer = issuer;
        _audience = audience;
    }
    
    public bool ValidateSender(string tokenString, string email)
    {
        if (tokenString == string.Empty) 
            return false;
        var token = ValidateToken(tokenString);
        
        var tokenEmail = token?.Claims.FirstOrDefault(x => x.Value == email)?.Value;
        if (tokenEmail == null)
            return false;
        return tokenEmail == email;
    }

    private JwtSecurityToken? ValidateToken(string inputToken)
    {
        var handler = new JwtSecurityTokenHandler();
        try
        {
            IConfigurationManager<OpenIdConnectConfiguration> configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>($"{_issuer}.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
            var openIdConfig = configurationManager.GetConfigurationAsync(CancellationToken.None).GetAwaiter().GetResult();
            
            handler.ValidateToken(inputToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKeys = openIdConfig.SigningKeys,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                ClockSkew = new TimeSpan(0, 0, 5)
            }, out SecurityToken validatedToken);
            return (JwtSecurityToken)validatedToken;
        }
        catch (Exception e)
        {
            //Logger.Log($"UNAUTHORIZED ACCESS\r\nReason: {e.Message}\r\nToken: {token}", Severity.Warning);
            return null;
        }
    }
}