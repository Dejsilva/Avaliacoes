using AvaliacaoMvc.Web.UI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AvaliacaoMvc.Web.UI.Models
{
    public class AlunoRepository
    {
      
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CadastrarAluno(AlunoModel novoAluno)
        {

            
            novoAluno.idade = DateTime.Now.Year - novoAluno.DataNascimento.Year;
            _context.Aluno.Add(novoAluno);
            _context.SaveChanges();
            
        }

        public List<AlunoModel> ListaAlunos()
        {

            List<AlunoModel> alunos = _context.Aluno.ToList();

            return alunos;              
                
        }
        public AlunoModel BuscarPorId(int id)
        {
           AlunoModel aluno = _context.Aluno.FirstOrDefault(x => x.Id == id);

            return aluno;
        }

        public void Editar(AlunoModel aluno, AlunoModel alunoEditado)
        {

            aluno.Nome = alunoEditado.Nome;
            aluno.Peso = alunoEditado.Peso;
            aluno.Altura = alunoEditado.Altura;

            _context.SaveChanges();
        }

        [HttpGet]
        public void Deletar(int id)
        {
            AlunoModel alunoModel = _context.Aluno.FirstOrDefault(x => x.Id == id);
          
            _context.Aluno.Remove(alunoModel);
            _context.SaveChanges();
        }
        [HttpPost]
        public List<AlunoModel> BuscarPorNome(string nome)
        {
            List<AlunoModel> alunoModel = _context.Aluno.Where(x => EF.Functions.Like(x.Nome, $"%{nome}%")).ToList();
            return alunoModel;
        }

    }
}
