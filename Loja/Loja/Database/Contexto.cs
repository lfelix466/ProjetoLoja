using Loja.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja.Database
{
    public class Contexto : DbContext 
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }   

        public DbSet<Produto> Produtos { get; set; } 
    }
}
