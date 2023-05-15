using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosAPI.Model;

namespace UsuariosAPI.Services
{
    public class TokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            //A classe Claim é uma declaração sobre uma entidade, como um usuário, contendo informações como nome, e-mail, função, permissões, entre outras. Essas afirmações são usadas para conceder acesso a recursos com base nas características ou propriedades do usuário.
            //A classe "Claims" permite que você crie e manipule objetos de afirmação em seu aplicativo. Essas afirmações podem ser usadas para fornecer autorização granular com base nas características do usuário, para fins de auditoria, personalização de experiência do usuário, entre outros.
            Claim[] claims = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id),
                new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString()),
                new Claim("loginTimestamp", DateTime.UtcNow.ToString())
            };

            //Gera chave para ser usada no signinCredentials
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DASUIOJFGUIOEFUODSAHF02319847U23018974UWQSAIHJDIPOHA"));

            //Gera uma credencial a partir da chave criada
            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
                );

            //Token é escrito para uma cadeia de caracteres e é retornado
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}