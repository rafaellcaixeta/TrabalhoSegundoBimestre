using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entidades
{
    public class Matricula
    {
        private object pIdAluno;
        private object pIdCurso;
        private object pDataMatricula;
        private object pAtivo;

        public Matricula(object pIdAluno, object pIdCurso, object pDataMatricula, object pAtivo)
        {
            this.pIdAluno = pIdAluno;
            this.pIdCurso = pIdCurso;
            this.pDataMatricula = pDataMatricula;
            this.pAtivo = pAtivo;
        }

        public int IdAluno { get; private set; }
        public int IdCurso { get; private set; }
        public DateTime DataMatricula { get; private set; }
        public bool Ativo { get; private set; }

    }
}
