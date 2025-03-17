using AutoMapper;
using GerenciamentoFinanceiro.Model;

namespace GerenciamentoFinanceiro.DTOs.Mappings
{
    public class TransacaoDTOMapping : Profile
    {
        public TransacaoDTOMapping()
        {
            CreateMap<TransacaoDTO, Transacao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Transacao, TransacaoDTO>();
        }
    }
    
}
