using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entidades
{
    public class Aluno
    {
        public Aluno(int IdAluno, string Nome, string Cpf, string Matricula, string Email)
        {
            this.IdAluno = IdAluno;
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.Matricula = Matricula;
            this.Email = Email;
        }

        public int IdAluno { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Matricula { get; private set; }
        public string Email { get; private set; }


    }

    public static class AlunoFactory
    {
        public static Aluno NovoAluno(string pNome, string pCpf, string pMatricula, string pEmail)
        {
            return new Aluno(0, pNome, pCpf, pMatricula, pEmail);
        }

        public static Aluno AlunoExistente(int pIdAluno, string pNome, string pCpf, string pMatricula, string pEmail)
        {
            return new Aluno(pIdAluno, pNome, pCpf, pMatricula, pEmail);
        }
    }
}
