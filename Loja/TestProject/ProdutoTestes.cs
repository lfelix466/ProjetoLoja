using Loja.Models;
namespace TestProject
{
    public class ProdutoTestes
    {
        private Produto? produto { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            produto = new Produto(); // Defina o preço ou outras propriedades conforme necessário
        }

        [Test]
        public void precoValidoTesteVerdadeiro()
        {
            Assert.That(produto.precoValido(10), Is.True);
        }

        [Test]
        public void precoValidoTesteFalso()
        {
            Assert.That(produto.precoValido(-20), Is.False);
        }
    }
}
