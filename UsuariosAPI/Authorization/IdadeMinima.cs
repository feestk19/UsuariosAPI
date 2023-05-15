using Microsoft.AspNetCore.Authorization;

namespace UsuariosAPI.Authorization
{
    //Classe utilizada pela classe program para atribuir um valor de idadeMinima na política de acesso
    public class IdadeMinima : IAuthorizationRequirement
    {
        public IdadeMinima(int idade) 
        {
            Idade = idade;
        }

        public int Idade { get; set; }
    }
}
