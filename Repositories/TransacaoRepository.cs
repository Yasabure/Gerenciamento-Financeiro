using GerenciamentoFinanceiro.Data;
using GerenciamentoFinanceiro.Model;

namespace GerenciamentoFinanceiro.Repositories
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
