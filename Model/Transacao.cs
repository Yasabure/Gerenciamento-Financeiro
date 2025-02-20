using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GerenciamentoFinanceiro.Enums;

namespace GerenciamentoFinanceiro.Model
{
    public class Transacao
    {
        public int Id { get; set; }
        [Required]
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
