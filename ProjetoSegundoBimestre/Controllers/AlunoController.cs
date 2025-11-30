using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using ProjetoSegundoBimestre.DTO.Request;

namespace ProjetoSegundoBimestre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet("api/AlunoController/obter_todos")]
        public IActionResult ObterTodos()
        {
            var ListaAlunos = _alunoService.ObterTodos();

            if (ListaAlunos is null) return NotFound("Nenhum aluno encontrado.");
            return Ok(ListaAlunos);
        }

        [HttpPost("api/AlunoController/adicionar")]
        public IActionResult Adicionar(NovoAlunoRequest novoAlunoRequest)
        {
            _alunoService.Adicionar(AlunoFactory.NovoAluno(novoAlunoRequest.nome, novoAlunoRequest.cpf, novoAlunoRequest.matricula, novoAlunoRequest.email));
       
            return Ok("Aluno adicionado com sucesso!");
        }

        [HttpPut("api/AlunoController/atualizar")]
        public IActionResult Atualizar(AtualizarAlunoRequest atualizarAlunoRequest)
        {
            _alunoService.Atualizar(AlunoFactory.AlunoExistente(atualizarAlunoRequest.idAluno, atualizarAlunoRequest.nome, atualizarAlunoRequest.cpf, atualizarAlunoRequest.matricula, atualizarAlunoRequest.email));

            return Ok("Aluno atualizado com sucesso!");
        }

        [HttpGet("api/aluno/obter-por-id/{id}")]

        public IActionResult ObterPorId(int id)
        {
            var aluno = _alunoService.ObterPorId(id);

            if (aluno is null) return NotFound("Aluno não encontrado.");
            return Ok(aluno);
        }

        [HttpGet("api/aluno/obter-por-cpf/{cpf}")]

        public IActionResult ObterPorCpf(string cpf)
        {
            var aluno = _alunoService.ObterPorCpf(cpf);

            if (aluno is null) return NotFound("Aluno não encontrado.");
            return Ok(aluno);
        }

        [HttpGet("api/aluno/obter-por-matricula/{matricula}")]
        public IActionResult ObterPorMatricula(string matricula)
        {
            var aluno = _alunoService.ObterPorMatricula(matricula);
            if (aluno is null) return NotFound("Aluno não encontrado.");
            return Ok(aluno);
        }

        [HttpDelete("api/aluno/remover")]
        public IActionResult Remover (int idAluno)
        {
            var aluno = _alunoService.ObterPorId(idAluno);

            if (aluno is null) return NotFound("Aluno não encontrado.");
            
            _alunoService.Deletar(idAluno);
            return NoContent();
        }
    }
}