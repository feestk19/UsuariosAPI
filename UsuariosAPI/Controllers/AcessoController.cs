using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoController : ControllerBase
    {
        //Método que valida a autorização de acesso
        [HttpGet]
        [Authorize(Policy = "IdadeMinima")]//Condição de autorização
        public IActionResult Get()
        {
            return Ok("Acesso permitido!");
        }
    }
}
