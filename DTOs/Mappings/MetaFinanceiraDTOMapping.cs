using AutoMapper;
using GerenciamentoFinanceiro.Model;

namespace GerenciamentoFinanceiro.DTOs.Mappings
{
    public class MetaFinanceiraDTOMapping : Profile
    {
        public MetaFinanceiraDTOMapping()
        {
            CreateMap<MetaFinanceiraDTO, MetaFinanceira>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<MetaFinanceira, MetaFinanceiraDTO>();
        }
    }
}
