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
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoria _categoria;

        public CategoriaController(ICategoria categoria)
        {
            _categoria = categoria;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            var categoriaList = await _categoria.Get();
            return Ok(categoriaList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetById(int id)
        {
            var categoria = await _categoria.GetById(id);
            return Ok(categoria);
        }


        [HttpGet("subcategoria/{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaAndSubCategorias(int id)
        {
            var categoriaAndSub = await _categoria.GetCategoriaAndSubCategoria(id);
            return Ok(categoriaAndSub);
        }


        [HttpPost]
        public async Task<ActionResult<Categoria>> Create([FromBody] Categoria categoria)
        {
            var categoriaReturn = await _categoria.Create(categoria);
            return Created("", categoriaReturn);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Update(int id, [FromBody] Categoria categoria)
        {
            var categoriaReturn = await _categoria.Update(id, categoria);
            return Ok(categoriaReturn);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var deleted = await _categoria.Delete(id);
            return Ok(deleted);
        }

    }
}
