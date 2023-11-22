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
            var cursos = await _curso.GetAsync();
            return Ok(cursos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetById(int id)
        {
            var curso = await _curso.GetByIdAsync(id);
            return Ok(curso);
        }


        [HttpPost]
        public async Task<ActionResult<Curso>> Create([FromBody] Curso curso)
        {
            await _curso.AddAsync(curso);
            return Created("", curso);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<Curso>> Update(int id, [FromBody] Curso curso)
        {
            var cursoToUpdate = await _curso.GetByIdAsync(id);

            cursoToUpdate.Nome = curso.Nome;
            cursoToUpdate.Descricao = curso.Descricao;
            cursoToUpdate.SubCategoriaId = curso.SubCategoriaId;

            await _curso.UpdateAsync(cursoToUpdate);
            return Ok(cursoToUpdate);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _curso.DeleteAsync(id);
            return Ok();
        }

    }
}
