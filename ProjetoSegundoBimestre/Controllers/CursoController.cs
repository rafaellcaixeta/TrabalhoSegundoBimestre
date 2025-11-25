using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using ProjetoSegundoBimestre.DTO.Request;

namespace Projeto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpPost]
        public IActionResult Adicionar(NovoCursoRequest novoCursoRequest)
        {
            _cursoService.Adicionar(
                CursoFactory.NovoCurso(
                    0,
                    novoCursoRequest.nome,
                    novoCursoRequest.nomeCoordenador,
                    true
                    ));
            return Ok("Curso adicionado com sucesso!");
        }

        [HttpPut]
        public IActionResult Atualizar(AtualizarCursoRequest atualizarCursoRequest)
        {
            try
            {
                var cursoAtualizado = new Curso(
                    atualizarCursoRequest.cursoID,
                    atualizarCursoRequest.nome,
                    atualizarCursoRequest.nomeCoordenador,
                    atualizarCursoRequest.ativo
                    );

                _cursoService.Atualizar(cursoAtualizado);

                return Ok("Curso atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}