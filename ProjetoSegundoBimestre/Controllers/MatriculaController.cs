using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using ProjetoSegundoBimestre.DTO.Request;

namespace ProjetoSegundoBimestre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatriculaController : Controller
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpGet("api/matricula/obter_todos")]
        public IActionResult ObterTodos()
        {
            var lista = _matriculaService.ObterTodos();
            if (lista is null) return NotFound("Nenhuma matrícula encontrada.");
            return Ok(lista);
        }

        [HttpPost("api/matricula/adicionar")]
        public IActionResult Adicionar(NovaMatriculaRequest request)
        {
            var matricula = MatriculaFactory.NovaMatricula(
                request.IdAluno,
                request.IdCurso,
                request.DataMatricula
            );

            _matriculaService.Adicionar(matricula);

            return Ok("Matrícula adicionada com sucesso!");
        }

        [HttpPut("api/matricula/atualizar")]
        public IActionResult Atualizar(AtualizarMatriculaRequest request)
        {
            var matricula = MatriculaFactory.MatriculaExistente(
                request.IdAluno,
                request.IdCurso,
                request.DataMatricula,
                request.Ativo
            );

            _matriculaService.Atualizar(matricula);

            return Ok("Matrícula atualizada com sucesso!");
        }

        [HttpGet("api/matricula/obter")]
        public IActionResult Obter(int idAluno, int idCurso)
        {
            var matricula = _matriculaService.ObterPorIdAluno(idAluno);

            if (matricula is null) return NotFound("Matrícula não encontrada.");
            return Ok(matricula);
        }


        [HttpDelete("api/matricula/remover")]
        public IActionResult Remover(int idAluno, int idCurso)
        {
            var matricula = _matriculaService.ObterPorIdAluno(idAluno);

            if (matricula is null) return NotFound("Matrícula não encontrada.");
            return Ok(matricula);
        }
    }
}
