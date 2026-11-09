using AvaliacaoMvc.Web.UI.Data;
using AvaliacaoMvc.Web.UI.Models;

namespace AvaliacaoMvc.Web.UI.Repository
{
    public class ProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CadastrarProduto(ProdutoModel novoProduto)
        {
            _context.Produto.Add(novoProduto);
            _context.SaveChanges();
        }
    }
}
