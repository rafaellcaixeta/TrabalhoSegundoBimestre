using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using ProjetoSegundoBimestre.DTO.Request;

namespace ProjetoSegundoBimestre.Controllers
{
    [ApiController]
    [Route("api/curso")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet("api/CursoController/obter_todos")]
        public IActionResult ObterTodos()
        {
            var cursos = _cursoService.ObterTodos();

            if (cursos == null || !cursos.Any())
                return NotFound("Nenhum curso encontrado.");

            return Ok(cursos);
        }

        [HttpGet("obter-por-id/{idCurso}")]
        public IActionResult ObterPorId(int idCurso)
        {
            var curso = _cursoService.ObterPorId(idCurso);

            if (curso == null)
                return NotFound("Curso não encontrado.");

            return Ok(curso);
        }

        [HttpPost("api/CursoController/adicionar")]
        public IActionResult Adicionar(NovoCursoRequest request)
        {
            var novoCurso = CursoFactory.NovoCurso(
                request.idCurso,
                request.nome,
                request.nomeCoordenador,
                request.ativo
            );

            _cursoService.Adicionar(novoCurso);

            return Ok("Curso adicionado com sucesso!");
        }

        [HttpPut("api/CursoController/atualizar")]
        public IActionResult Atualizar(AtualizarCursoRequest request)
        {
            var cursoExistente = CursoFactory.CursoExistente(
                request.idCurso,
                request.nome,
                request.nomeCoordenador,
                request.ativo
            );

            _cursoService.Atualizar(cursoExistente);

            return Ok("Curso atualizado com sucesso!");
        }

        [HttpDelete("remover/{idCurso}")]
        public IActionResult Remover(int idCurso)
        {
            var curso = _cursoService.ObterPorId(idCurso);

            if (curso == null)
                return NotFound("Curso não encontrado.");

            _cursoService.Deletar(idCurso);

            return NoContent();
        }
    }
}
