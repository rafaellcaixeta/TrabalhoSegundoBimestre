using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repositorios
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly string _connectionString;

        public MatriculaRepository(IConfiguration configuration)

        {

            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public void Adicionar(Matricula matricula)
        {
            var sql = "INSERT INTO Matricula (IdAluno,IdCurso, DataMatricula, Ativo) " +

            "VALUES (@IdAluno, @IdCurso, @DataMatricula,@Ativo)";

            using (var conn = new SqlConnection(_connectionString))

            using (var cmd = new SqlCommand(sql, conn))

            {

                cmd.Parameters.AddWithValue("@IdAluno", matricula.IdAluno);

                cmd.Parameters.AddWithValue("@IdCurso", matricula.IdCurso);

                cmd.Parameters.AddWithValue("@DataMatricula", matricula.DataMatricula);

                cmd.Parameters.AddWithValue("@Ativo", matricula.Ativo);



                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void Atualizar(Matricula matricula)
        {
            var sql = "UPDATE Matricula SET IdCurso = @IdCurso, DataMatricula = @DataMatricula, Ativo = @Ativo" +

                       " WHERE IdAluno = @IdAluno";



            using (var conn = new SqlConnection(_connectionString))

            using (var cmd = new SqlCommand(sql, conn))

            {

                cmd.Parameters.AddWithValue("@IdCurso", matricula.IdCurso);

                cmd.Parameters.AddWithValue("@DataMatricula", matricula.DataMatricula);

                cmd.Parameters.AddWithValue("@Ativo", matricula.Ativo);



                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void Deletar(Matricula matricula)
        {
            var sql = "DELETE FROM Matricula " + " WHERE IdAluno = @IdAluno";



            using (var conn = new SqlConnection(_connectionString))

            using (var cmd = new SqlCommand(sql, conn))

            {

                cmd.Parameters.AddWithValue("@IdAluno", matricula.IdAluno);



                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public Matricula ObterPorId(int idAluno, int idCurso)
        {
            var sql = "SELECT IdAluno, IdCurso, DataMatricula, Ativo FROM Matricula";



            using (var conn = new SqlConnection(_connectionString))

            using (var cmd = new SqlCommand(sql, conn))

            {

                conn.Open();

                using (var reader = cmd.ExecuteReader())

                {

                    if (reader.Read())

                    {

                        return new Matricula

                        (

                          reader.GetInt32(0),

                          reader.GetInt32(1),

                          reader.GetDateTime(2),

                          reader.GetBoolean(3)
                        );

                    }

                    return null;

                }

            }
        }

        public List<Matricula> ObterPorIdAluno(int IdAluno)
        {
            var lista = new List<Matricula>();

            var sql = "SELECT IdAluno, IdCurso, DataMatricula, Ativo FROM Matricula WHERE IdAluno = @IdAluno";

            using (var conn = new SqlConnection(_connectionString))

            using (var cmd = new SqlCommand(sql, conn))

            {
                cmd.Parameters.AddWithValue("@IdAluno", IdAluno);

                conn.Open();

                using (var reader = cmd.ExecuteReader())

                {
                    while (reader.Read())

                    {
                        var produto = new Matricula

                        (
                          reader.GetInt32(0),

                          reader.GetInt32(1),

                          reader.GetDateTime(2),

                          reader.GetBoolean(3)

                        );

                        lista.Add(produto);
                    }
                }
            }

            return lista;
        }

        public List<Matricula> ObterPorIdCurso(int IdCurso)
        {
            var lista = new List<Matricula>();

            var sql = "SELECT IdAluno, IdCurso, DataMatricula, Ativo FROM Matricula WHERE IdAluno = @IdAluno";

            using (var conn = new SqlConnection(_connectionString))

            using (var cmd = new SqlCommand(sql, conn))

            {
                cmd.Parameters.AddWithValue("@IdCurso", IdCurso);

                conn.Open();

                using (var reader = cmd.ExecuteReader())

                {
                    while (reader.Read())

                    {
                        var produto = new Matricula

                        (
                          reader.GetInt32(0),

                          reader.GetInt32(1),

                          reader.GetDateTime(2),

                          reader.GetBoolean(3)

                        );

                        lista.Add(produto);
                    }
                }
            }

            return lista;
        }

        public List<Matricula> ObterTodos()
        {
            var lista = new List<Matricula>();

            var sql = "SELECT IdAluno, IdCurso, DataMatricula, Ativo FROM Matricula";

            using (var conn = new SqlConnection(_connectionString))

            using (var cmd = new SqlCommand(sql, conn))

            {

                conn.Open();

                using (var reader = cmd.ExecuteReader())

                {

                    while (reader.Read())

                    {

                        var produto = new Matricula

                        (

                          reader.GetInt32(0),

                          reader.GetInt32(1),

                          reader.GetDateTime(2),

                          reader.GetBoolean(3)

                        );

                        lista.Add(produto);

                    }

                }

            }

            return lista;
        }
    }
}