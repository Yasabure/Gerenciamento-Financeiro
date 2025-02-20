using System.ComponentModel.DataAnnotations;
using GerenciamentoFinanceiro.Enums;

namespace GerenciamentoFinanceiro.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty ;
        [Required]
        [StringLength(100)]
        public string Senha { get; set; } = string .Empty ;
        [Required]
        public TipoUsuario TipoUsuario { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
    }
}
