using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversorMoedas.API.Models
{
    [Table("moedas")]
    public class Moeda
    {
        [Key]
        [Column("mda_id")]
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Column("mda_nome")]
        public string Nome { get; set; }

        [Required]
        [Column("mda_preco_compra")]
        public decimal PrecoCompra { get; set; }

        [Required]
        [Column("mda_preco_venda")]
        public decimal PrecoVenda { get; set; }

        [Required]
        [StringLength (3, MinimumLength = 3)]
        [Column("mda_cod")]
        public string Cod { get; set; }

        [Required]
        [Column("mda_data")]
        public DateTime Data { get; set; }
    }
}
