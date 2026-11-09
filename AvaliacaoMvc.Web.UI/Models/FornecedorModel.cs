using AvaliacaoMvc.Web.UI.Data;

namespace AvaliacaoMvc.Web.UI.Models
{
    public class FornecedorModel
    {

        private readonly AppDbContext _context;

        public FornecedorModel(AppDbContext context)
        {
            _context = context;
        }

        public int id { get; set; }
        public string nomeFornecedor { get; set; }
        public string Contato { get; set; }
        public string cep { get; set; }

        public FornecedorModel()
        {
        }

    }
}
