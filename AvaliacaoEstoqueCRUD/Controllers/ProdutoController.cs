using AvaliacaoEstoqueCRUD.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoEstoqueCRUD.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoRepository produtoCadastro)
        {
            ProdutoRepository produto = new ProdutoRepository();
            

            produto.Cadastrar(produtoCadastro);

            ViewBag.Cadastrado = "Produto Cadastrado";

            int? contador = HttpContext.Session.GetInt32("Contador");

            if (contador == null)
            {
                contador = 0;
                contador++;
                HttpContext.Session.SetInt32("Contador", (int)contador);
            }
            else
            {
                contador++;
                HttpContext.Session.SetInt32("Contador", (int)contador);
            }


            return View(produtoCadastro);
        }

        [HttpGet]
  
        public IActionResult ListaProdutos()
        {
            ProdutoRepository produto = new ProdutoRepository();
            List<ProdutoRepository> produtos = produto.Listar();

            HttpContext.Session.GetInt32("Contador");

            return View(produtos);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ProdutoRepository produto = new ProdutoRepository();
            List<ProdutoRepository> produtos = new List<ProdutoRepository>();

            produtos = produto.Listar();
            ProdutoRepository produtoEditar = produtos.Find(x=>x.id == id);

            return View(produtoEditar);

        }

        [HttpPost]
        public IActionResult Editar(ProdutoRepository produtoEdit)
        {
            ProdutoRepository produto = new ProdutoRepository();
            produto.Editar(produtoEdit);

            List<ProdutoRepository> produtos = produto.Listar();


            ViewBag.Editado = "Editado Com Sucesso";

            int? contador = HttpContext.Session.GetInt32("Contador");

            if (contador == null)
            {
                contador = 0;
                contador++;
                HttpContext.Session.SetInt32("Contador", (int)contador);
            }
            else
            {
                contador++;
                HttpContext.Session.SetInt32("Contador", (int)contador); 
            }

            ProdutoRepository pro =  produtos.Find(x => x.id == produtoEdit.id);
            
            pro.contadorEdit++;

            
            
            HttpContext.Session.SetInt32("ContadorEd", pro.contadorEdit);
             
            
  
            return View(produtoEdit);
        }
    }
}
