using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ApiAuth;

public class TokenService
{
    public static string GenerateToken(User user) //retorna string, token final
    {
        var tokenHandler = new JwtSecurityTokenHandler(); //classe pra gerar token
        var key = Encoding.ASCII.GetBytes(Settings.Secret); //chave para encodar a chave e transformar em array de bytes
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim(ClaimTypes.Name, user.Username), //mapeia para o user.identity.name TEM Q SER UMA STRING
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddHours(2), // -> quanto tempo o token vai durar
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

}
