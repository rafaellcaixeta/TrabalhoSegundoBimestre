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
        public void Deletar(Matricula matricula);
        public List<Matricula> ObterTodos();
        public Matricula ObterPorId(int idAluno, int idCurso);
        public List<Matricula> ObterPorIdAluno(int IdAluno);
        public List<Matricula> ObterPorIdCurso(int IdCurso);
        
    }
}
