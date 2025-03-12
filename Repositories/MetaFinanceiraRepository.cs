using GerenciamentoFinanceiro.Data;
using GerenciamentoFinanceiro.Model;

namespace GerenciamentoFinanceiro.Repositories
{
    public class MetaFinanceiraRepository : Repository<MetaFinanceira>, IMetaFinanceiraRepository
    {
        public MetaFinanceiraRepository(AppDbContext context) : base(context)
        {

        }
    }
}
