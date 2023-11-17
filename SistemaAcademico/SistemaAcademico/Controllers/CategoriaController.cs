using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;

namespace SistemaAcademico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly SistemaAcademicoDbContext _context;

        public CategoriaController(SistemaAcademicoDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            // Utilizando o método AsNoTracking para ganho de performace
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetById(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(p => p.CategoriaId == id);

            if (categoria is null) return BadRequest("Categoria procurada pelo Id: " + id + " Está nula");

            return Ok(categoria);
        }


        [HttpGet("subcategoria/{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaAndSubCategorias(int id)
        {
            var categoriaAndSub = await _context.Categorias.Include(p => p.SubCategorias).AsNoTracking().FirstOrDefaultAsync(p => p.CategoriaId == id);

            if (categoriaAndSub is null) return BadRequest("Não Encontrado");

            return Ok(categoriaAndSub);
        }


        [HttpPost]
        public async Task<ActionResult<Categoria>> Create([FromBody] Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return Created("", categoria);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Update(int id, [FromBody] Categoria categoria)
        {
            var categoriaById = await _context.Categorias.FirstOrDefaultAsync(p => p.CategoriaId == id);

            if (categoriaById is null) return BadRequest("Categoria procurada pelo Id: " + id + " Está nula");

            categoriaById.Nome = categoria.Nome;
            categoriaById.Descricao = categoria.Descricao;

            _context.Categorias.Update(categoriaById);
            await _context.SaveChangesAsync();

            return Ok(categoriaById);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var categoriaById = await _context.Categorias.FindAsync(id);

            if (categoriaById is null) return BadRequest(false);

            _context.Categorias.Remove(categoriaById);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

    }
}
