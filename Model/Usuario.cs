using System.ComponentModel.DataAnnotations;
using GerenciamentoFinanceiro.Enums;
using Microsoft.AspNetCore.Identity;

namespace GerenciamentoFinanceiro.Model
{
    public class Usuario : IdentityUser
    {

        [Required]
        public TipoUsuario TipoUsuario { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        // Relacionamento 1:N com Transacao
        public List<Transacao> Transacoes { get; set; } = new();

        // Relacionamento 1:N com MetaFinanceira
        public List<MetaFinanceira> MetasFinanceiras { get; set; } = new();

        // Relacionamento 1:N com DespesasFixas
        public List<DespesasFixas> DespesasFixas { get; set; } = new();
    }
}
