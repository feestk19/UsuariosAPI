using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Model
{
    public class Usuario : IdentityUser //Herda da Classe IdentityUser
    {
        public DateTime DataNascimento { get; set; }
        public Usuario() : base() { }//Será possível utilizar campo personalizado junto com atributos da classe IdentityUser
    }
}
