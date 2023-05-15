using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Model;

namespace UsuariosAPI.Services
{
    //Podemos enfrentar problemas caso toda a nossa lógica esteja inserida diretamente em nosso controlador.
    //Quando aumentarmos o código, as responsabilidades vão se misturar. Uma alternativa para contornar tal problema é criar classes contendo cada lógica específica.
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _usermanager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(UserManager<Usuario> usermanager, IMapper mapper, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _usermanager = usermanager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
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

        public async Task<string> Login(LoginUsuarioDto dto)
        {
            //Com o método PasswordSignInAsync é possível efetuar login utilizando usuário e senha.
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }
    }
}
