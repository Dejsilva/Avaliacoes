using AvaliacaoMvc.Web.UI.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoMvc.Web.UI.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AlunoModel> Aluno { get; set; }

        public DbSet<ProdutoModel> Produto { get; set; }

        public DbSet<FornecedorModel> Fornecedor { get; set; }

    }
}
