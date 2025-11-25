using Projeto.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Interfaces
{
    public interface IMatriculaService
    {
        public void Adicionar(Matricula matricula);
        public void Atualizar(Matricula matricula);
        public void Deletar(int idAluno, int idCurso);
        public List<Aluno> ObterTodos();
        public Aluno ObterPorId(int idAluno, int idCurso);
        public List<Matricula> ObterPorIdAluno(int IdAluno);
        public List<Matricula> ObterPorIdCurso(int IdCurso);
    }
}
