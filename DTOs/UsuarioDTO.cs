using System.ComponentModel.DataAnnotations;

namespace GerenciamentoFinanceiro.DTOs
{
    public class UsuarioDTO
    {

            [Required]
            [StringLength(80)]
            public string Nome { get; set; } = string.Empty;

            [Required]
            [StringLength(100)]
            public string Email { get; set; } = string.Empty;

            [Required]
            [StringLength(100)]
            public string Senha { get; set; } = string.Empty;
    }
}
