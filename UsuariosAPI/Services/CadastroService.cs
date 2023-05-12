using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Model;

namespace UsuariosAPI.Services
{
    //Podemos enfrentar problemas caso toda a nossa lógica esteja inserida diretamente em nosso controlador.
    //Quando aumentarmos o código, as responsabilidades vão se misturar. Uma alternativa para contornar tal problema é criar classes contendo cada lógica específica.
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _usermanager;

        public CadastroService(UserManager<Usuario> usermanager, IMapper mapper)
        {
            _usermanager = usermanager;
            _mapper = mapper;
        }

        public async Task Cadastra(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            //await espera a execução de um método assíncrono
            IdentityResult resultado = await _usermanager.CreateAsync(usuario, dto.Password);

            if (resultado.Succeeded)
            {
                
            }
            else
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }



    }
}
