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
            var categoriaList = await _categoria.GetAsync();
            return Ok(categoriaList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetById(int id)
        {
            var categoria = await _categoria.GetByIdAsync(id);
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
            await _categoria.AddAsync(categoria);
            return Created("", categoria);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Update(int id, [FromBody] Categoria categoria)
        {
            var categoriaToUpdate = await _categoria.GetByIdAsync(id);

            categoriaToUpdate.Nome = categoria.Nome;
            categoriaToUpdate.Descricao = categoria.Descricao;

            await _categoria.UpdateAsync(categoriaToUpdate);
            return Ok(categoria);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _categoria.DeleteAsync(id);
            return Ok();
        }

    }
}
