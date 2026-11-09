using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AvaliacaoEstoqueCRUD.Repository
{
    public class ProdutoRepository
    {
        
        public int id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatorio")]
        [StringLength(255, ErrorMessage = "O nome deve ter no maximo 255 caracteres")]
        public string nome { get; set; }
        [Required(ErrorMessage = "O preço é obrigatorio")]
        [Range(0.01, 100000.00,ErrorMessage = "o preço deve etar entre 0.01, 100000.00")]
        public  decimal preco { get; set; }
        [Required(ErrorMessage = "A quantidade é obrigatoria")]
        [Range(0, 100000, ErrorMessage = "A quantidade deve estar entre 0 e 100000")]
        public int quantidade { get; set; }
        public string categoria { get; set; }

        public int contadorEdit { get; set; } 


        public void Cadastrar(ProdutoRepository objProduto)
        {
                SqlConnection connection = new SqlConnection(
                "Server=FAC0716239W11-1;" +
                "Database=ControleEstoque;" +
                "User Id=sa;" +
                "Password=123456;" +
                "TrustServerCertificate=True;"
                );
            connection.Open();

            string sql = "INSERT INTO Produto (nome, preco, quantidade, categoria) VALUES (@nome, @preco, @quantidade, @categoria)";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@nome", objProduto.nome);
            cmd.Parameters.AddWithValue("@preco", objProduto.preco);
            cmd.Parameters.AddWithValue("@quantidade", objProduto.quantidade);
            cmd.Parameters.AddWithValue("@categoria", objProduto.categoria);
            cmd.ExecuteNonQuery();

        }

        public List<ProdutoRepository> Listar()
        {
            List<ProdutoRepository> listaProdutos = new List<ProdutoRepository>();
            SqlConnection connection = new SqlConnection(
                "Server=FAC0716239W11-1;" +
                "Database=ControleEstoque;" +
                "User Id=sa;" +
                "Password=123456;" +
                "TrustServerCertificate=True;"
                );
            connection.Open();
            string sql = "SELECT * FROM Produto";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listaProdutos.Add(new ProdutoRepository
                {
                    id = Convert.ToInt32(reader["idProduto"]),
                    nome = reader["nome"].ToString(),
                    preco = Convert.ToDecimal(reader["preco"]),
                    quantidade = Convert.ToInt32(reader["quantidade"]),
                    categoria = reader["categoria"].ToString()
                });

            }
            return listaProdutos;
        }

        public void Editar(ProdutoRepository objProduto)
        {
            SqlConnection connection = new SqlConnection(
                "Server=FAC0716239W11-1;" +
                "Database=ControleEstoque;" +
                "User Id=sa;" +
                "Password=123456;" +
                "TrustServerCertificate=True;"
                );
            connection.Open();
            string sql = "UPDATE Produto SET nome=@nome, preco=@preco, quantidade=@quantidade, categoria = @categoria WHERE idProduto=@id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", objProduto.id);
            cmd.Parameters.AddWithValue("@nome", objProduto.nome);
            cmd.Parameters.AddWithValue("@preco", objProduto.preco);
            cmd.Parameters.AddWithValue("@quantidade", objProduto.quantidade);
            cmd.Parameters.AddWithValue("@categoria", objProduto.categoria);
            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            SqlConnection connection = new SqlConnection(
                "Server=FAC0716239W11-1;" +
                "Database=ControleEstoque;" +
                "User Id=sa;" +
                "Password=123456;" +
                "TrustServerCertificate=True;"
                );
            connection.Open();
            string sql = "DELETE FROM Produto WHERE id=@id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
