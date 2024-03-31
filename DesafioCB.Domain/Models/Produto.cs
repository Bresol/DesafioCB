using System.ComponentModel.DataAnnotations;

namespace DesafioCB.Domain.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
