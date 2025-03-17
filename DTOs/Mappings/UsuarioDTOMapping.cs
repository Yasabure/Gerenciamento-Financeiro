using AutoMapper;
using GerenciamentoFinanceiro.Enums;
using GerenciamentoFinanceiro.Model;

namespace GerenciamentoFinanceiro.DTOs.Mappings
{
    public class UsuarioDTOMapping : Profile
    {
        public UsuarioDTOMapping()
        {
            CreateMap<UsuarioDTO, Usuario>()
           .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => TipoUsuario.Cliente))
           .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Usuario, ExibirUsuarioDTO>();

            CreateMap<AtualizarUsuarioDTO, Usuario>()
                .ForMember(dest => dest.DataCadastro, opt => opt.Ignore());

            CreateMap<Usuario, AtualizarUsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>();


        }
    }
}
