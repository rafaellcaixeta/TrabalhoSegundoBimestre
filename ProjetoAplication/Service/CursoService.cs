using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.Service
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public void Adicionar(Curso curso)
        {
            if (string.IsNullOrEmpty(curso.Nome))
                throw new Exception("O nome do curso é obrigatório.");

            if (_cursoRepository.ObterTodos().Any(c => c.Nome == curso.Nome))
                throw new Exception("Já existe um curso com esse nome.");

            if (string.IsNullOrEmpty(curso.NomeCoordenador))
                throw new Exception("O nome do coordenador é obrigatório.");

            _cursoRepository.Adicionar(curso);
        }

        public void Atualizar(Curso curso)
        {
            Curso buscaCurso = _cursoRepository.ObterPorId(curso.IdCurso);

            if (buscaCurso == null)
                throw new Exception("Curso não encontrado ou não existente.");
            _cursoRepository.Atualizar(curso);
        }

        public void Deletar(int IDcurso)
        {
            Curso buscaCurso = _cursoRepository.ObterPorId(IDcurso);
            if (buscaCurso == null)
                throw new Exception("Curso não encontrado ou não existente.");

            _cursoRepository.Deletar(IDcurso);
        }

        public bool VerificarSeAtivo(int IDcurso)
        {
            var curso = _cursoRepository.ObterPorId(IDcurso);

            if (curso == null)
                throw new Exception("Curso não encontrado ou não existente.");

            if(!curso.Ativo)
                throw new Exception("Curso inativo.");

            return true;
        }

        public List<Curso> ObterTodos()
        {
            return _cursoRepository.ObterTodos();
        }

        public Curso ObterPorId(int IdCurso)
        {
            var curso = _cursoRepository.ObterPorId(IdCurso);
            if (curso == null)
                throw new Exception("Curso não encontrado ou não existente.");

            if (!curso.Ativo)
                throw new Exception("Curso inativo.");

            return _cursoRepository.ObterPorId(IdCurso);
        }
    }
}