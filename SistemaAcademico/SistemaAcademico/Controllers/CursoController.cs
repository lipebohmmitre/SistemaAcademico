using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.DTOs;
using SistemaAcademico.DTOs.DTOsExpecifics;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Services.Interfaces;
using System.Runtime.InteropServices;

namespace SistemaAcademico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {

        private readonly ICurso _curso;
        private readonly IMapper _mapper;

        public CursoController(ICurso curso, IMapper mapper)
        {
            _curso = curso;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoDTO>>> Get()
        {
            var cursos = await _curso.GetAsync();

            var dto = _mapper.Map<List<CursoDTO>>(cursos);

            return Ok(dto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDTO>> GetById(int id)
        {
            var curso = await _curso.GetByIdAsync(id);

            if (curso is null) return BadRequest("Não Encontrado");

            var dto = _mapper.Map<CursoDTO>(curso);

            return Ok(dto);
        }

        [HttpGet("/cursosDetails")]
        public async Task<ActionResult<IEnumerable<CursoAndSubCategoriaDTO>>> GetCursosDetails()
        {
            var cursosDetails = await _curso.GetCursosSubCategoriasAndCategorias();

            var dto = _mapper.Map<List<CursoAndSubCategoriaDTO>>(cursosDetails);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<CursoDTO>> Create([FromBody] CursoDTO cursoDto)
        {

            var curso = _mapper.Map<Curso>(cursoDto);

            await _curso.AddAsync(curso);

            var dto = _mapper.Map<CursoDTO>(curso);

            return Created("", dto);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<CursoDTO>> Update(int id, [FromBody] CursoDTO cursoDto)
        {
            var cursoToUpdate = await _curso.GetByIdAsync(id);

            cursoToUpdate.Nome = cursoDto.Nome;
            cursoToUpdate.Descricao = cursoDto.Descricao;
            cursoToUpdate.SubCategoriaId = cursoDto.SubCategoriaId;

            await _curso.UpdateAsync(cursoToUpdate);

            var dto = _mapper.Map<CursoDTO>(cursoToUpdate);

            return Ok(dto);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _curso.DeleteAsync(id);
            return Ok();
        }

    }
}
