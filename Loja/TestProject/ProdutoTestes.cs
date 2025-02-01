using Loja.Models;
namespace TestProject
{
    public class ProdutoTestes
    {
        private Produto produto { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            produto = new Produto(); // Defina o preço ou outras propriedades conforme necessário
        }

        [Test]
        public void precoValidoTesteVerdadeiro()
        {
            if (produto != null)
            {
                Assert.That(produto.precoValido(10), Is.True);
            }
        }

        [Test]
        public void precoValidoTesteFalso()
        {
            if (produto != null)
            {
                Assert.That(produto.precoValido(-20), Is.False);
            }
        }
    }
}
