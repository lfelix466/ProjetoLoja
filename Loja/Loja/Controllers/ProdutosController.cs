using Microsoft.AspNetCore.Mvc;
using Loja.Database;
using Loja.Models;
using Loja.Repositories;
using Loja.Services;

namespace Loja.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly Contexto _context;
        private readonly ProdutoRepository produtoRepository;
        private readonly ServicosImagem servicosImagem;

        public ProdutosController(Contexto context, ProdutoRepository produtoRepository, ServicosImagem servicosImagem)
        {
            _context = context;
            this.produtoRepository = produtoRepository; // inicializando o produtoRepository
            this.servicosImagem = servicosImagem; // inicializando o servicosImagem
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View(await produtoRepository.listarProdutos());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View(await produtoRepository.listarProdutosPorId(id));
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto, IFormFile imagem)
        {

            var imagemConvertida = await servicosImagem.converteImagem(imagem);

            if (imagemConvertida == null)
            {
                return NotFound();
            }
            else
            {
                produto.Imagem = imagemConvertida;
            }

            // Remover a validação de ModelState para a propriedade Imagem
            //ModelState.Remove("Imagem");

            if (ModelState.IsValid)
            {
                if (await produtoRepository.Criar(produto))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var produto = await produtoRepository.ProcurarPorId(id);

            if (produto == null)
            {
                return NotFound(); // Retorna 404 se o produto não for encontrado
            }

            return View(produto); // Retorna a view com o produto encontrado
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nome, Preco, Imagem")] Produto produto, IFormFile imagem)
        {

            if (imagem != null)
            {
                produto.Imagem = await servicosImagem.converteImagem(imagem);
            }

            ModelState.Remove("Imagem");

            if (ModelState.IsValid)
            {
                if (await produtoRepository.Atualizar(produto))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await produtoRepository.ProcurarPorId(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await produtoRepository.Deletar(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}
