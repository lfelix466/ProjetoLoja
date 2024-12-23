using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
        public decimal Preco { get; set; }

        [Required]
        [Column("imagem")]
        [Display(Name = "Imagem")]
        public byte[]? Imagem { get; set; }

        public bool precoValido(float preco)
        {
            try
            {
                if (preco <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Tratamento genérico para qualquer outra exceção
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

    }
}
