using GerenciamentoFinanceiro.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoFinanceiro.DTOs
{
    public class TransacaoDTO
    {
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        [Required]
        public TipoTransacao TipoTransacao { get; set; }
        [Required]
        public CategoriaTransacao Categoria { get; set; }
        [Required]
        public DateTime Data { get; set; }
    }
}
