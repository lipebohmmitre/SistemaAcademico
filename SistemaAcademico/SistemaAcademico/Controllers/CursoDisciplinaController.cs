using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoDisciplinaController : ControllerBase
    {

        private readonly ICursoDisciplina _cursoDisciplina;

        public CursoDisciplinaController(ICursoDisciplina cursoDisciplina)
        {
            _cursoDisciplina = cursoDisciplina;
        }



        [HttpGet("{idCurso}")]
        public async Task<ActionResult<Curso>> GetCursoDisciplinas(int idCurso)
        {
            var cursoDisciplinas = await _cursoDisciplina.GetCursoAndDisciplina(idCurso);
            return Ok(cursoDisciplinas);
        }



        [HttpPatch("{idDisciplina}/{idCurso}")]
        public async Task<ActionResult<Disciplina>> AdicionarCursoNaDisciplina(int idDisciplina, int idCurso)
        {
            var cursoDisciplina = await _cursoDisciplina.AdicionarCursoNaDisciplina(idDisciplina, idCurso);
            return Ok(cursoDisciplina);
        }


 
        [HttpPatch("listaDisciplinas/{idCurso}")]
        public async Task<ActionResult<Curso>> AdicionarListaDisciplinasEmCurso(int idCurso, [FromBody] IEnumerable<int> idDisciplinas)
        {
            var cursoDisciplina = await _cursoDisciplina.AdicionarListaDisciplinasEmCurso(idCurso, idDisciplinas);
            return Ok(cursoDisciplina);
        }

    }
}
