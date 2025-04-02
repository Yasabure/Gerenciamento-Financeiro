using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GerenciamentoFinanceiro.Enums;

namespace GerenciamentoFinanceiro.Model
{
    public class DespesasFixas
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        [Required]
        public FrequenciaDespesa Frequencia { get; set; }
        [Required]
        public DateTime ProximaData { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public CategoriaTransacao Categoria { get; set; }
    }
}
