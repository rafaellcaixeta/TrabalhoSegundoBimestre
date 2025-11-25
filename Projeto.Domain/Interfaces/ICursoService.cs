using Projeto.Domain.Entidades;
using System.Collections.Generic;

namespace Projeto.Domain.Interfaces
{
    public interface ICursoService
    {
        void Adicionar(Curso curso);
        void Atualizar(Curso curso);
        void Deletar(int IdCurso);
        List<Curso> ObterTodos();
        Curso ObterPorId(int IdCurso);
    }
}
