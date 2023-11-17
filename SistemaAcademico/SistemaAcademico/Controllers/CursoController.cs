using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;

namespace SistemaAcademico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {

        private readonly SistemaAcademicoDbContext _context;

        public CursoController(SistemaAcademicoDbContext context)
        {
            _context = context;   
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> Get()
        {
            var cursos = await _context.Cursos.AsNoTracking().ToListAsync();
            return Ok(cursos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetById(int id)
        {
            var curso = await _context.Cursos.AsNoTracking().FirstOrDefaultAsync(p => p.CursoId == id);

            if (curso is null) return BadRequest("Curso nulo");

            return Ok(curso);
        }


        [HttpPost]
        public async Task<ActionResult<Curso>> Create([FromBody] Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();

            return Created("", curso);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso is null) return BadRequest(false);

            return Ok(true);
        }

    }
}
