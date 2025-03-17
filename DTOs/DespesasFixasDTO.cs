using GerenciamentoFinanceiro.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoFinanceiro.DTOs
{
    public class DespesasFixasDTO
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        [Required]
        public CategoriaTransacao Categoria { get; set; }
        [Required]
        public FrequenciaDespesa Frequencia { get; set; }
        [Required]
        public DateTime ProximaData { get; set; }
    }
}
