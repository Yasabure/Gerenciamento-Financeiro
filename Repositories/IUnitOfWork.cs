namespace GerenciamentoFinanceiro.Repositories
{
    public interface IUnitOfWork
    {
        IDespesasFixasRepository DespesasFixasRepository { get; }
        IMetaFinanceiraRepository MetaFinanceiraRepository { get; }
        ITransacaoRepository TransacaoRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        Task CommitAsync();
    }
}
