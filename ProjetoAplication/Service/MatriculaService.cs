using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.Service
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly ICursoRepository _cursoRepository;

        public MatriculaService(IMatriculaRepository matriculaRepository, IAlunoRepository alunoRepository, ICursoRepository cursoRepository)
        {
            _matriculaRepository = matriculaRepository;
            _alunoRepository = alunoRepository;
            _cursoRepository = cursoRepository;
        }

        public void Adicionar(Matricula matricula)
        {
            var aluno = _alunoRepository.ObterPorId(matricula.IdAluno);
            if (aluno == null)
                throw new Exception("Aluno não encontrado ou inexistente.");

            var curso = _cursoRepository.ObterPorId(matricula.IdCurso);
            if (curso == null)
                throw new Exception("Curso não encontrado ou inexistente.");

            if (!curso.Ativo)
                throw new Exception("Não é possível matricular em um curso inativo.");

            var matriculasAlunos = _matriculaRepository.ObterPorIdAluno(matricula.IdAluno);
            bool jaMatriculado = matriculasAlunos.Any(m => m.IdCurso == matricula.IdCurso);

            if (jaMatriculado)
                throw new Exception("Aluno já está matriculado neste curso.");

            var novaMatricula = new Matricula(matricula.IdAluno, matricula.IdCurso, DateTime.Now, true);

            _matriculaRepository.Adicionar(novaMatricula);
        }

        public void Atualizar(Matricula matricula)
        {
            var buscaMatricula = _matriculaRepository.ObterPorId(matricula.IdAluno, matricula.IdCurso);

            if (buscaMatricula == null)
                throw new Exception("Matrícula não encontrada ou inexistente.");

            _matriculaRepository.Atualizar(matricula);
        }

        public void Deletar(int idAluno, int idCurso)
        {
            var buscaMatricula = _matriculaRepository.ObterPorId(matricula.IdAluno, matricula.IdCurso);

            if (buscaMatricula == null)
                throw new Exception("Matrícula não encontrada ou inexistente.");

            _matriculaRepository.Deletar(Idmatricula);
        }

        public bool VerificarSeAtivo(int idAluno, int idCurso)
        {
            var matricula = _matriculaRepository.ObterPorId(idAluno, idCurso);
            if (matricula == null)
                throw new Exception("Matrícula não encontrada ou inexistente.");

            return _matriculaRepository.VerificarSeAtivo(idAluno, idCurso);
        }

        public Matricula ObterPorId(int idAluno, int idCurso)
        {
            var matricula = _matriculaRepository.ObterPorId(idAluno, idCurso);

            if (matricula == null)
                throw new Exception("Matrícula não encontrada ou inexistente.");

            if (!matricula.Ativo)
                throw new Exception("Matrícula inativa.");

            return matricula;
        }

        public List<Matricula> ObterPorAluno(int IdAluno)
        {
            var matriculas = _matriculaRepository.ObterPorIdAluno(IdAluno);

            if (matriculas == null || !matriculas.Any())
                throw new Exception("Nenhuma matrícula encontrada para o aluno informado.");

            return matriculas;
        }

        public List<Matricula> ObterPorCurso(int IdCurso)
        {
            var matriculas = _matriculaRepository.ObterPorIdCurso(IdCurso);
            if (matriculas == null || !matriculas.Any())
                throw new Exception("Nenhuma matrícula encontrada para o curso informado.");

            return matriculas;
        }

        public List<Aluno> ObterTodos()
        {
            throw new NotImplementedException();
        }

        Aluno IMatriculaService.ObterPorId(int idAluno, int idCurso)
        {
            throw new NotImplementedException();
        }

        public List<Matricula> ObterPorIdAluno(int IdAluno)
        {
            throw new NotImplementedException();
        }

        public List<Matricula> ObterPorIdCurso(int IdCurso)
        {
            throw new NotImplementedException();
        }
    }
}