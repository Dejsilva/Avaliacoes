using AvaliacaoMvc.Web.UI.Data;
using AvaliacaoMvc.Web.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoMvc.Web.UI.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AppDbContext _context;

        public AlunoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(AlunoModel alunoCadastro)
        {
            
            AlunoRepository Aluno = new AlunoRepository(_context);
            List<AlunoModel> Alunos = Aluno.ListaAlunos();

            ViewBag.MaiorAluno = Alunos.MaxBy(x => x.Altura);
            Aluno.CadastrarAluno(alunoCadastro);
           
            return View(alunoCadastro);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            AlunoRepository Aluno = new AlunoRepository(_context);
            List<AlunoModel> Alunos = Aluno.ListaAlunos();

            ViewBag.ListaAlunos = Alunos.OrderByDescending(x => x.Altura).ToList();

            return View(Alunos);
        }
        [HttpGet]
        public IActionResult BuscarPorId()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BuscarPorId(int idAluno)
        {
            AlunoRepository alunoRepo = new AlunoRepository(_context);
            AlunoModel aluno = alunoRepo.BuscarPorId(idAluno);
            List<AlunoModel> alunos = alunoRepo.ListaAlunos();

            return View(aluno);
        }

        public IActionResult Editar()
        {
            return View();
        }
      
        public IActionResult Editar(int idAluno)
        {
            AlunoRepository alunoRepo = new AlunoRepository(_context);
            AlunoModel aluno = alunoRepo.BuscarPorId(idAluno);

            return View(aluno);
        }
        [HttpGet]
        public IActionResult Editar(AlunoModel alunoEditado)
        {
            // AlunoRepository aluno = new AlunoRepository(_context);
            //AlunoModel alunoModel = aluno.BuscarPorId(alunoEditado.Id);

            //aluno.Editar(alunoModel, alunoEditado);

            int ? idAluno = HttpContext.Session.GetInt32("idAluno");

            if (idAluno == null)
            {
                return RedirectToAction("Login", "Aluno");
            }

            AlunoRepository alunoRepo = new AlunoRepository(_context);
            AlunoModel aluno = alunoRepo.BuscarPorId(idAluno.Value);


            return View(aluno);
        }
        [HttpGet]
        public IActionResult Deletar(int idAluno)
        {
            AlunoRepository alunoRepo = new AlunoRepository(_context);
            AlunoModel aluno = alunoRepo.BuscarPorId(idAluno);

            return View(aluno);
        }
        [HttpPost]
        public IActionResult Deletar(AlunoModel alunoDeletado)
        {
            AlunoRepository aluno = new AlunoRepository(_context);
            aluno.BuscarPorId(alunoDeletado.Id);

            aluno.Deletar(alunoDeletado.Id);

            return View();
        }

        [HttpGet]
        public IActionResult BuscarNome(string nome)
        {
            AlunoRepository alunoRepo = new AlunoRepository(_context);
            List<AlunoModel> aluno = alunoRepo.BuscarPorNome(nome);

            return View(aluno);
              
        }

        public IActionResult Login(AlunoModel alunoLogin)
        {
            AlunoRepository alunoRepo = new AlunoRepository(_context);
            List<AlunoModel> alunos =alunoRepo.ListaAlunos();

            AlunoModel aluno = alunos.FirstOrDefault(x => x.Nome == alunoLogin.Nome &&  x.idade >= 18);

            if (aluno != null)
            {
                HttpContext.Session.SetInt32("idAluno", aluno.Id);
                HttpContext.Session.SetString("NomeAluno", aluno.Nome);

                return RedirectToAction("Editar", "Aluno");
            }

            return View();

        }
    }
}
