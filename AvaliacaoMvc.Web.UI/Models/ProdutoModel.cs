using AvaliacaoMvc.Web.UI.Data;

namespace AvaliacaoMvc.Web.UI.Models
{
    public class ProdutoModel

    {
        private readonly AppDbContext _context;
        public ProdutoModel (AppDbContext context)
        {
            _context = context;
        }

        public int id { get; set; }
        public string nomeProduto { get; set; }
        public string descricaoProduto { get; set; }
        public decimal preco { get; set; }
        public decimal custo { get; set; }

        public FornecedorModel fornecedor { get; set; }

        public ProdutoModel()
        {

        }
    }
}
