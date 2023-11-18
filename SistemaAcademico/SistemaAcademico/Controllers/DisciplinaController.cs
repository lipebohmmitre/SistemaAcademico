using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;

namespace SistemaAcademico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {

        private readonly SistemaAcademicoDbContext _context;

        public DisciplinaController(SistemaAcademicoDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disciplina>>> Get()
        {
            return await _context.Disciplinas.AsNoTracking().ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Disciplina>> GetById(int id)
        {
            var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(p => p.DisciplinaId == id);

            if(disciplina is null) return NotFound("Está nula");

            return Ok(disciplina);
        }


        [HttpPost]
        public async Task<ActionResult<Disciplina>> Create([FromBody] Disciplina disciplina)
        {
            await _context.Disciplinas.AddAsync(disciplina);
            await _context.SaveChangesAsync();

            return Created("", disciplina);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<Disciplina>> Update(int id, [FromBody] Disciplina disciplina)
        {
            var disciplinaById = await _context.Disciplinas.FindAsync(id);

            if (disciplinaById is null) return BadRequest("Está nulo");

            disciplinaById.Nome = disciplina.Nome;
            disciplinaById.CargaHoraria = disciplina.CargaHoraria;
            disciplinaById.TipoDisciplina = disciplina.TipoDisciplina;

            _context.Disciplinas.Update(disciplinaById);
            await _context.SaveChangesAsync();

            return Ok(disciplinaById);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var disciplina = await _context.Disciplinas.FindAsync(id);

            if (disciplina is null) return BadRequest(false);

            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();

            return Ok(true);
        }




        // Funcionou, porem quando tentei adicionar 1, 1 ocorreu erro de chaves iguais, olhar depois
        [HttpPatch("{idDisciplina}/{idCurso}")]
        public async Task<ActionResult<Disciplina>> AdicionarCursoNaDisciplina(int idDisciplina, int idCurso)
        {
            Disciplina disciplina = await _context.Disciplinas.FirstOrDefaultAsync(p => p.DisciplinaId == idDisciplina);
            Curso curso = await _context.Cursos.FirstOrDefaultAsync(p => p.CursoId == idCurso);

            if (disciplina is null || curso is null) return BadRequest();

            disciplina.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return Ok(disciplina);
        }


        // Melhorar Código
        [HttpPatch("listaDisciplinas/{idCurso}")]
        public async Task<ActionResult<Curso>> AdicionarListaDisciplinasEmCurso(int idCurso, [FromBody] IEnumerable<int> idDisciplinas)
        {
            var curso = await _context.Cursos.FirstOrDefaultAsync(p => p.CursoId == idCurso);
            List<Disciplina> disciplinasList = new List<Disciplina>();

            foreach(var item in idDisciplinas)
            {
                var disciplinaById = await _context.Disciplinas.FirstOrDefaultAsync(p => p.DisciplinaId == item);
                disciplinasList.Add(disciplinaById);
            }

            foreach(var item in  disciplinasList)
            {
                curso.Disciplinas.Add(item);
                
            }
            await _context.SaveChangesAsync();
            return Ok(curso);
        }

    }
}
