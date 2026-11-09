using AspNetCoreGeneratedDocument;
using AvaliacaoMvc.Web.UI.Data;
using AvaliacaoMvc.Web.UI.Models;
using AvaliacaoMvc.Web.UI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoMvc.Web.UI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(ProdutoModel produtoCadastrado)
        {
            ProdutoRepository produto = new ProdutoRepository(_context);


            return View();

        }
    }
}
