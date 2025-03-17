using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoFinanceiro.DTOs
{
    public class MetaFinanceiraDTO
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        [Required]
        public DateTime DataLimite { get; set; }
        [Required]
        public Boolean Status { get; set; } = true;
    }
}
