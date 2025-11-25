using Projeto.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Interfaces
{
    public interface ICursoRepository
    {
        public void Adicionar(Curso curso);
        public void Atualizar(Curso curso);
        public void Deletar(int IdCurso);
        public List<Curso> ObterTodos();
        public Curso ObterPorId(int IdCurso);
    }
}
