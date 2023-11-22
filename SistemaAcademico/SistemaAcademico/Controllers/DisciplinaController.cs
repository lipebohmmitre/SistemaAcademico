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
    public class DisciplinaController : ControllerBase
    {

        private readonly IDisciplina _disciplina;
        private readonly IMapper _mapper;

        public DisciplinaController(IDisciplina disciplina, IMapper mapper)
        {
            _disciplina = disciplina;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplinaDTO>>> Get()
        {
            var disciplinas = await _disciplina.GetAsync();

            var dto = _mapper.Map<List<DisciplinaDTO>>(disciplinas);

            return Ok(dto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplinaDTO>> GetById(int id)
        {
            var disciplina = await _disciplina.GetByIdAsync(id);

            var dto = _mapper.Map<DisciplinaDTO>(disciplina);

            return Ok(dto);
        }


        [HttpPost]
        public async Task<ActionResult<DisciplinaDTO>> Create([FromBody] DisciplinaDTO disciplinaDto)
        {
            var disciplina = _mapper.Map<Disciplina>(disciplinaDto);

            await _disciplina.AddAsync(disciplina);

            var dto = _mapper.Map<DisciplinaDTO>(disciplina);

            return Created("", dto);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<DisciplinaDTO>> Update(int id, [FromBody] DisciplinaDTO disciplinaDto)
        {
            var disciplinaToUpdate = await _disciplina.GetByIdAsync(id);

            disciplinaToUpdate.Nome = disciplinaDto.Nome;
            disciplinaToUpdate.TipoDisciplina = disciplinaDto.TipoDisciplina;
            disciplinaToUpdate.CargaHoraria = disciplinaDto.CargaHoraria;

            await _disciplina.UpdateAsync(disciplinaToUpdate);

            var dto = _mapper.Map<DisciplinaDTO>(disciplinaToUpdate);

            return Ok(dto);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _disciplina.DeleteAsync(id);
            return Ok();
        }


















        /*

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
        */
    }
}
