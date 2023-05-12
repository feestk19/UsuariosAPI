using AutoMapper;//Lib responsável por mapear
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Model;

namespace UsuariosAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
