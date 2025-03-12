using GerenciamentoFinanceiro.Data;

namespace GerenciamentoFinanceiro.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public  AppDbContext _Context;
        private IDespesasFixasRepository? _DespesasFixasRepository;
        private IMetaFinanceiraRepository? _MetaFinanceiraRepository;
        private ITransacaoRepository? _TransacaoRepository;
        private IUsuarioRepository? _UsuarioRepository;


        public UnitOfWork(AppDbContext context)
        {
            _Context = context;
        }

        public IDespesasFixasRepository DespesasFixasRepository
        {
            get
            {
                return _DespesasFixasRepository = _DespesasFixasRepository ?? new DespesasFixasRepository(_Context);
            }
        }
        public IMetaFinanceiraRepository MetaFinanceiraRepository
        {
            get
            {
                return _MetaFinanceiraRepository = _MetaFinanceiraRepository ?? new MetaFinanceiraRepository(_Context);
            }
        }

        public ITransacaoRepository TransacaoRepository
        {
            get
            {
                return _TransacaoRepository = _TransacaoRepository ?? new TransacaoRepository(_Context);
            }
        }
        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                return _UsuarioRepository = _UsuarioRepository ?? new UsuarioRepository(_Context);
            }
        }

        public async Task CommitAsync()
        {
            await _Context.SaveChangesAsync();
        }
        public  void Dispose()
        {
            _Context.Dispose();
        }
    }
}
