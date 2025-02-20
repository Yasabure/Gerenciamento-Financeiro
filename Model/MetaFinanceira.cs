using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoFinanceiro.Model
{
    public class MetaFinanceira
    {
        public int Id { get; set; }
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
