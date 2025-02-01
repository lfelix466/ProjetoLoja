using System.ComponentModel;
using System.Configuration;
using Loja.Database;
using Loja.Models;
using Loja.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loja.Repositories
{
    public class ProdutoRepository
    {
        private readonly Contexto _context;

        public ProdutoRepository(Contexto context)
        {
            _context = context;
        }

        public async Task<List<Produto>> listarProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> listarProdutosPorId(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var produto = await _context.Produtos
              .FirstOrDefaultAsync(m => m.Id == id); // Busca o produto pelo ID.

            return produto;
        }

        public async Task<bool> Criar(Produto produto)
        {

            try
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Atualizar(Produto produto)
        {

            var produtoExistente = _context.Produtos.Find(produto.Id);

            if (produtoExistente == null)
            {
                return false;
            }
            else
            {
                produtoExistente.Nome = produto.Nome;
                produtoExistente.Preco = produto.Preco;

                if (produto.Imagem != null)
                {
                    produtoExistente.Imagem = produto.Imagem;
                }
            }

            try
            {
                _context.Update(produtoExistente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<Produto?> ProcurarPorId(int? id)
        {
            if (id == null)
            {
                return null;

            }
            else
            {

                try
                {
                    var produto = await _context.Produtos.FindAsync(id); // Busca o produto pelo id
                    return produto; // Retorna o produto ou null se não encontrado
                }
                catch (Exception e)
                {
                    return null; // Retorna null em caso de erro
                }
            }
        }

        public async Task<bool> Deletar(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return false;
            }
            try
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        }
}
