using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {

        private readonly ICurso _curso;

        public CursoController(ICurso curso)
        {
            _curso = curso;   
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> Get()
        {
            var cursos = await _curso.Get();
            return Ok(cursos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetById(int id)
        {
            var curso = await _curso.GetById(id);
            return Ok(curso);
        }


        [HttpPost]
        public async Task<ActionResult<Curso>> Create([FromBody] Curso curso)
        {
            var cursoReturn = await _curso.Create(curso);
            return Created("", cursoReturn);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<Curso>> Update(int id, [FromBody] Curso curso)
        {
            var cursoById = await _curso.Update(id, curso);
            return Ok(cursoById);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var curso = await _curso.Delete(id);
            return Ok(curso);
        }

    }
}
