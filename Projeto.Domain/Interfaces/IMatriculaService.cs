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
        void Adicionar(Matricula matricula);
        void Atualizar(Matricula matricula);
        void Deletar(int idMatricula);
        List<Matricula> ObterTodos();
        Matricula ObterPorId(int idMatricula);
        List<Matricula> ObterPorIdAluno(int idAluno);
        List<Matricula> ObterPorIdCurso(int idCurso);
    }
}
