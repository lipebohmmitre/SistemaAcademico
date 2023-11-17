using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;

namespace SistemaAcademico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase
    {

        private readonly SistemaAcademicoDbContext _context;

        public SubCategoriaController(SistemaAcademicoDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoria>>> Get()
        {
            // Utilizando o método AsNoTracking para ganho de performace
            return await _context.SubCategorias.AsNoTracking().ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoria>> GetById(int id)
        {
            var subCategoria = await _context.SubCategorias.AsNoTracking().FirstOrDefaultAsync(p => p.SubCategoriaId == id);

            if (subCategoria is null) return BadRequest("A SubCategoria de Id: " + id + " está nula");

            return Ok(subCategoria);
        }


        [HttpGet("cursos/{id}")]
        public async Task<ActionResult<SubCategoria>> GetSubCategoriaAndCurso(int id)
        {
            var subCategoria = await _context.SubCategorias.Include(p => p.Cursos).SingleOrDefaultAsync(p => p.SubCategoriaId == id);

            if (subCategoria is null) return BadRequest("Está nulo");

            return Ok(subCategoria);
        }


        [HttpPost]
        public async Task<ActionResult<SubCategoria>> Create([FromBody] SubCategoria subCategoria)
        {
            await _context.SubCategorias.AddAsync(subCategoria);
            await _context.SaveChangesAsync();

            return Created("", subCategoria);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<SubCategoria>> Update(int id, [FromBody] SubCategoria subCategoria)
        {
            var subCategoriaById = await _context.SubCategorias.FindAsync(id);

            if(subCategoriaById is null) return BadRequest("A SubCategoria de Id: " + id + " está nula");

            subCategoriaById.Nome = subCategoria.Nome;
            subCategoriaById.Descricao = subCategoria.Descricao;
            subCategoriaById.CategoriaId = subCategoria.CategoriaId;

            _context.SubCategorias.Update(subCategoriaById);
            await _context.SaveChangesAsync();

            return Ok(subCategoriaById);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var subCategoria = await _context.SubCategorias.FindAsync(id);

            if (subCategoria is null) return BadRequest(false);

            _context.SubCategorias.Remove(subCategoria);
            await _context.SaveChangesAsync();

            return Ok(true);
        }


    }
}
