using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Service
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        
        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public void Adicionar(Aluno aluno)
        {
           Aluno buscaAluno = _alunoRepository.ObterPorCpf(aluno.Cpf);
            if (buscaAluno != null)
            {
                throw new Exception("Já existe um aluno cadastrado com esse CPF.");
            }

            Aluno buscaMatricula = _alunoRepository.ObterPorMatricula(aluno.Matricula);
            if (buscaMatricula != null)
            {
                throw new Exception("Já existe um aluno cadastrado com essa matrícula.");
            }

            _alunoRepository.Adicionar(aluno);
        }

        public void Atualizar(Aluno aluno)
        {
            Aluno buscaAluno = _alunoRepository.ObterPorId(aluno.IdAluno);
            if (buscaAluno == null)
            {
                throw new Exception("Aluno não encontrado.");
            }

            buscaAluno = _alunoRepository.ObterPorCpf(aluno.Cpf);
            if (buscaAluno != null && buscaAluno.IdAluno != aluno.IdAluno)
            {
                throw new Exception("Já existe um aluno cadastrado com esse CPF.");
            }

            buscaAluno = _alunoRepository.ObterPorMatricula(aluno.Matricula);
            if( buscaAluno != null && buscaAluno.IdAluno != aluno.IdAluno)
            {
                throw new Exception("Já existe um aluno cadastrado com essa matrícula.");
            } 
        }

        public void Deletar(int idAluno)
        {
            Aluno buscaAluno = _alunoRepository.ObterPorId(idAluno);
            if (buscaAluno == null)
            {
                throw new Exception("Aluno não encontrado.");
            }
            _alunoRepository.Deletar(idAluno);
        }

        public Aluno ObterPorCpf(string cpf)
        {
            return _alunoRepository.ObterPorCpf(cpf);
        }

        public Aluno ObterPorId(int idAluno)
        {
            return _alunoRepository.ObterPorId(idAluno);
        }

        public Aluno ObterPorMatricula(string matricula)
        {
            return _alunoRepository.ObterPorMatricula(matricula);
        }

        public List<Aluno> ObterTodos()
        {
            var listaAlunos = _alunoRepository.ObterTodos();

            if (listaAlunos.Count == 0)
                throw new Exception("Nenhum aluno encontrado.");

            return _alunoRepository.ObterTodos();
        }
    }
}
