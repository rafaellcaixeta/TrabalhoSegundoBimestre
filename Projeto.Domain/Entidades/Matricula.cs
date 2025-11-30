using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entidades
{
    public class Matricula
    {
        public Matricula(int idAluno, int idCurso, DateTime dataMatricula, bool ativo)
        {
            IdAluno = idAluno;
            IdCurso = idCurso;
            DataMatricula = dataMatricula;
            Ativo = ativo;
        }

        public int IdMatricula { get; private set; }
        public int IdAluno { get; private set; }
        public int IdCurso { get; private set; }
        public DateTime DataMatricula { get; private set; }
        public bool Ativo { get; private set; }
    }

    public static class MatriculaFactory
    {
        public static Matricula NovaMatricula(int idAluno, int idCurso, DateTime dataMatricula)
        {
            return new Matricula(idAluno, idCurso, dataMatricula, true);
        }

        public static Matricula MatriculaExistente(int idAluno, int idCurso, DateTime dataMatricula, bool ativo)
        {
            return new Matricula(idAluno, idCurso, dataMatricula, ativo);
        }
    }
}
