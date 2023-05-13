using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Model;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[Controller]")]//Cria a rota de controller
public class UsuarioController : ControllerBase
{
    
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService cadastroService)
    {
        _usuarioService = cadastroService;
    }



    //Método de cadastrar usuários
    [HttpPost("cadastro")]//Define o verbo que a API utilizará na execução
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)//Assíncrono
    {
        await _usuarioService.Cadastra(dto);
        return Ok("Usuário cadastrado com sucesso!");


    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        await _usuarioService.Login(dto);
        return Ok("Usuário autenticado!");
    }


}
