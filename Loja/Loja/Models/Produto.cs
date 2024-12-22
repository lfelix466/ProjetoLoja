using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Required]
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = "";

        [Required]
        [Column("preco")]
        [Display(Name = "Preço")]
        public float Preco { get; set; }

        [Column("imagem")]
        [Display(Name = "Imagem")]
        public required byte[] Imagem { get; set; }
    }
}
