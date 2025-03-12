using GerenciamentoFinanceiro.Data;
using GerenciamentoFinanceiro.Model;

namespace GerenciamentoFinanceiro.Repositories
{
    public class DespesasFixasRepository : Repository<DespesasFixas>, IDespesasFixasRepository
    {
        public DespesasFixasRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
