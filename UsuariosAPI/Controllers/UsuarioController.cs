using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Model;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[Controller]")]//Cria a rota de controller
public class UsuarioController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<Usuario> _usermanager;

    public UsuarioController(IMapper mapper, UserManager<Usuario> usermanager)
    {
        _mapper = mapper;
        _usermanager = usermanager;
    }

    //Método de cadastrar usuários
    [HttpPost]//Define o verbo que a API utilizará na execução
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)//Assíncrono
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);

        //await espera a execução de um método assíncrono
        IdentityResult resultado = await _usermanager.CreateAsync(usuario, dto.Password);

        if (resultado.Succeeded) 
        {
            return Ok("Usuário cadastrado com sucesso!");
        }
        else
        {
            throw new ApplicationException("Falha ao cadastrar usuário!");
        }


    }


}
