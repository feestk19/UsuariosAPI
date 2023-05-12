using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[Controller]")]//Cria a rota de controller
public class UsuarioController : ControllerBase
{
    [HttpPost]//Define o verbo que a API utilizará na execução
    public IActionResult CadastraUsuario(CreateUsuarioDto dto)
    {
        throw new NotImplementedException();
    }


}
