using Projeto.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        public void Adicionar(Matricula matricula);
        public void Atualizar(Matricula matricula);
        public void Deletar(int idAluno, int idCurso);
        public List<Aluno> ObterTodos();
        public Aluno ObterPorId(int idAluno, int idCurso);
        public List<Matricula> ObterPorIdAluno(int IdAluno);
        public List<Matricula> ObterPorIdCurso(int IdCurso);
        bool VerificarSeAtivo(int idAluno, int v, int idCurso);
        bool VerificarSeAtivo(int idAluno, int idCurso);
        object ObterPorId(object idAluno, object idCurso);
    }
}
