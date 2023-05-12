using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)]//Define o tipo do dado como senha
        public string Password { get; set; }
        [Required]
        [Compare("Password")]//Anotação que realiza a comparação com algum campo desejado ("Password")
        public string RePassword { get; set; }
    }
}
