using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.DTOs;
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
        private readonly IMapper _mapper;

        public SubCategoriaController(ISubCategoria subCategoria, IMapper mapper)
        {
            _subCategoria = subCategoria;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoriaDTO>>> Get()
        {
            var subCategorias = await _subCategoria.GetAsync();
            var dto = _mapper.Map<List<SubCategoriaDTO>>(subCategorias);
            return Ok(dto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoriaDTO>> GetById(int id)
        {
            var subCategoria = await _subCategoria.GetByIdAsync(id);

            if (subCategoria is null) return BadRequest("Não Encontrado");

            var dto = _mapper.Map<SubCategoriaDTO>(subCategoria);

            return Ok(dto);
        }


        [HttpGet("cursos/{id}")]
        public async Task<ActionResult<SubCategoriaAndCursosDTO>> GetSubCategoriaAndCurso(int id)
        {
            var subCategoria = await _subCategoria.GetSubCategoriaAndCurso(id);

            var dto = _mapper.Map<SubCategoriaAndCursosDTO>(subCategoria);

            return Ok(dto);
        }


        [HttpPost]
        public async Task<ActionResult<SubCategoriaDTO>> Create([FromBody] SubCategoriaDTO subCategoriaDto)
        {
            var subCategoria = _mapper.Map<SubCategoria>(subCategoriaDto);

            await _subCategoria.AddAsync(subCategoria);

            var dto = _mapper.Map<SubCategoriaDTO>(subCategoria);

            return Created("", dto);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<SubCategoriaDTO>> Update(int id, [FromBody] SubCategoriaDTO subCategoriaDto)
        {
            var subCategoriasToUpdate = await _subCategoria.GetByIdAsync(id);



            subCategoriasToUpdate.Nome = subCategoriaDto.Nome;
            subCategoriasToUpdate.Descricao = subCategoriaDto.Descricao;

            await _subCategoria.UpdateAsync(subCategoriasToUpdate);

            var dto = _mapper.Map<SubCategoriaDTO>(subCategoriasToUpdate);

            return Ok(dto);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _subCategoria.DeleteAsync(id);
            return Ok();
        }


    }
}
