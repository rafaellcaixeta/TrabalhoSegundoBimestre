using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repositorios
{
    public class CursoRepository : ICursoRepository
    {
        private readonly string _connectionString;

        public CursoRepository(IConfiguration configuration)

        {

            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }
        public void Adicionar(Curso curso)
        {
            var sql = "INSERT INTO Curso (Nome,NomeCoordenador, Ativo) " +

             "VALUES (@Nome,@NomeCoordenador,@Ativo)";

            using (var conn = new SqlConnection(_connectionString))

            using (var cmd = new SqlCommand(sql, conn))

            {

                cmd.Parameters.AddWithValue("@nome", curso.Nome);

                cmd.Parameters.AddWithValue("@email", curso.NomeCoordenador);

                cmd.Parameters.AddWithValue("@matricula", curso.Ativo);



                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void Atualizar(Curso curso)
        {
            var sql = "UPDATE Aluno SET Nome = @Nome, NomeCoordenador = @NomeCoordenador, Ativo = @Ativo" +

             " WHERE IdCurso = @IdCurso";



            using (var conn = new SqlConnection(_connectionString))

            using (var cmd = new SqlCommand(sql, conn))

            {

                cmd.Parameters.AddWithValue("@Nome", curso.Nome);

                cmd.Parameters.AddWithValue("@NomeCoordenador", curso.NomeCoordenador);

                cmd.Parameters.AddWithValue("@Ativo", curso.Ativo);



                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void Deletar(int IdCurso)
        {
            var sql = "DELETE FROM Curso " + " WHERE IdCurso = @IdCurso";



            using (var conn = new SqlConnection(_connectionString))

            using (var cmd = new SqlCommand(sql, conn))

            {

                cmd.Parameters.AddWithValue("@IdCurso", IdCurso);



                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public Curso ObterPorId(int IdCurso)
        {
            var sql = "SELECT IdCurso, Nome, NomeCoordenador, Ativo FROM Curso";



            using (var conn = new SqlConnection(_connectionString))

            using (var cmd = new SqlCommand(sql, conn))

            {

                conn.Open();

                using (var reader = cmd.ExecuteReader())

                {

                    if (reader.Read())

                    {

                        return new Curso

                        (

                          reader.GetInt32(0),

                          reader.GetString(1),

                          reader.GetString(2),

                          reader.GetBoolean(3)
                        );

                    }

                    return null;

                }

            }
        }

        public List<Curso> ObterTodos()
        {
            var lista = new List<Curso>();

            var sql = "SELECT IdCurso, Nome, NomeCoordenador, Ativo FROM Curso";

            using (var conn = new SqlConnection(_connectionString))

            using (var cmd = new SqlCommand(sql, conn))

            {

                conn.Open();

                using (var reader = cmd.ExecuteReader())

                {

                    while (reader.Read())

                    {

                        var produto = new Curso

                        (

                          reader.GetInt32(0),

                          reader.GetString(1),

                          reader.GetString(2),

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
