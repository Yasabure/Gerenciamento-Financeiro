using GerenciamentoFinanceiro.Data;
using GerenciamentoFinanceiro.Model;

namespace GerenciamentoFinanceiro.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {

        }
    }
}
