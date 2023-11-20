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
            var subCategorias = await _subCategoria.Get();
            return Ok(subCategorias);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoria>> GetById(int id)
        {
            var subCategoria = await _subCategoria.GetById(id);
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
            var subCategorias = await _subCategoria.Create(subCategoria);
            return Created("", subCategorias);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<SubCategoria>> Update(int id, [FromBody] SubCategoria subCategoria)
        {
            var subCategorias = await _subCategoria.Update(id, subCategoria);
            return Ok(subCategorias);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var subCategorias = await _subCategoria.Delete(id);
            return Ok(subCategorias);
        }


    }
}
