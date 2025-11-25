using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entidades
{
    public class Curso
    {
        public Curso(int IdCurso, string Nome, string NomeCoordenador, bool Ativo)
        {
            this.IdCurso = IdCurso;
            this.Nome = Nome;
            this.NomeCoordenador = NomeCoordenador;
            this.Ativo = Ativo;
        }

        public int IdCurso { get; private set; }
        public string Nome { get; private set; }
        public string NomeCoordenador { get; private set; }
        public bool Ativo { get; private set; }
    }

    public static class CursoFactory
    {
        public static Curso NovoCurso(int pIdCurso, string pNome, string pNomeCoordenador, bool pAtivo)
        {
            return new Curso(0, pNome, pNomeCoordenador, pAtivo);
        }

        public static Curso CursoExistente(int pIdCurso, string pNome, string pNomeCoordenador, bool pAtivo)
        {
            return new Curso(pIdCurso, pNome, pNomeCoordenador, pAtivo);
        }
    }
}

