using GerenciamentoFinanceiro.Enums;

namespace GerenciamentoFinanceiro.DTOs
{
    public class ExibirUsuarioDTO
    {
        public Guid Id  { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public TipoUsuario TipoUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
