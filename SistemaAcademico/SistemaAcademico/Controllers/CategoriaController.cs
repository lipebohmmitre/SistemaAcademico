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
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoria _categoria;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoria categoria, IMapper mapper)
        {
            _categoria = categoria;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categoriaList = await _categoria.GetAsync();
            var categoriaDTO = _mapper.Map<List<CategoriaDTO>>(categoriaList);
            return Ok(categoriaDTO);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDTO>> GetById(int id)
        {
            var categoria = await _categoria.GetByIdAsync(id);

            if (categoria is null) return BadRequest("Não Encontrado");

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

            return Ok(categoriaDTO);
        }

        
        [HttpGet("subcategoria/{id}")]
        public async Task<ActionResult<CategoriaAndSubCategoriaDTO>> GetCategoriaAndSubCategorias(int id)
        {
            var categoriaAndSub = await _categoria.GetCategoriaAndSubCategoria(id);

            var dto = _mapper.Map<CategoriaAndSubCategoriaDTO>(categoriaAndSub);

            return Ok(dto);
        }
        

        [HttpPost]
        public async Task<ActionResult<Categoria>> Create([FromBody] CategoriaDTO categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);

            await _categoria.AddAsync(categoria);

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

            return Created("", categoriaDTO);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Update(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            var categoriaToUpdate = await _categoria.GetByIdAsync(id);

            categoriaToUpdate.Nome = categoriaDto.Nome;
            categoriaToUpdate.Descricao = categoriaDto.Descricao;

            await _categoria.UpdateAsync(categoriaToUpdate);

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoriaToUpdate);

            return Ok(categoriaDTO);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _categoria.DeleteAsync(id);
            return Ok();
        }

    }
}
