using AvaliacaoMvc.Web.UI.Data;

namespace AvaliacaoMvc.Web.UI.Models
{
    public class AlunoModel
    {
        private AppDbContext context;

        public AlunoModel(AppDbContext context)
        {
            this.context = context;
        }

        public int Id { get; set; }
        public string  Nome { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public DateTime DataNascimento { get; set; }
        public int idade { get; set; }

        public AlunoModel()
        {

        }
    }

   
}
