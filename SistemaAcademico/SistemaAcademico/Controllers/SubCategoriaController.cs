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
    public class SubCategoriaController : ControllerBase
    {

        private readonly ISubCategoria _subCategoria;

        public SubCategoriaController(ISubCategoria subCategoria)
        {
            _subCategoria = subCategoria;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoria>>> Get()
        {
            var subCategorias = await _subCategoria.GetAsync();
            return Ok(subCategorias);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoria>> GetById(int id)
        {
            var subCategoria = await _subCategoria.GetByIdAsync(id);
            return Ok(subCategoria);
        }


        [HttpGet("cursos/{id}")]
        public async Task<ActionResult<SubCategoria>> GetSubCategoriaAndCurso(int id)
        {
            var subCategoria = await _subCategoria.GetSubCategoriaAndCurso(id);
            return Ok(subCategoria);
        }


        [HttpPost]
        public async Task<ActionResult<SubCategoria>> Create([FromBody] SubCategoria subCategoria)
        {
            await _subCategoria.AddAsync(subCategoria);
            return Created("", subCategoria);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<SubCategoria>> Update(int id, [FromBody] SubCategoria subCategoria)
        {
            var subCategoriasToUpdate = await _subCategoria.GetByIdAsync(id);

            subCategoriasToUpdate.Nome = subCategoria.Nome;
            subCategoriasToUpdate.Descricao = subCategoria.Descricao;

            await _subCategoria.UpdateAsync(subCategoriasToUpdate);
            return Ok(subCategoriasToUpdate);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _subCategoria.DeleteAsync(id);
            return Ok();
        }


    }
}
