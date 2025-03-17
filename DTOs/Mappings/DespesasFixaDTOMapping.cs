using AutoMapper;
using GerenciamentoFinanceiro.Enums;
using GerenciamentoFinanceiro.Model;

namespace GerenciamentoFinanceiro.DTOs.Mappings
{
    public class DespesasFixaDTOMapping : Profile
    {
        public DespesasFixaDTOMapping()
        {
            CreateMap<DespesasFixasDTO, DespesasFixas>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<DespesasFixas, DespesasFixasDTO>();
        }
    }

}
