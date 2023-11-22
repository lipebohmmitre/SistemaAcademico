using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.DTOs;
using SistemaAcademico.Models;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoDisciplinaController : ControllerBase
    {

        private readonly ICursoDisciplina _cursoDisciplina;
        private readonly IMapper _mapper;

        public CursoDisciplinaController(ICursoDisciplina cursoDisciplina, IMapper mapper)
        {
            _cursoDisciplina = cursoDisciplina;
            _mapper = mapper;
        }



        [HttpGet("{idCurso}")]
        public async Task<ActionResult<CursoAndDiscplinaDTO>> GetCursoDisciplinas(int idCurso)
        {
            var cursoDisciplinas = await _cursoDisciplina.GetCursoAndDisciplina(idCurso);

            var dto = _mapper.Map<CursoAndDiscplinaDTO>(cursoDisciplinas);

            return Ok(dto);
        }



        [HttpPatch("{idCurso}/{idDisciplina}")]
        public async Task<ActionResult<CursoAndDiscplinaDTO>> AdicionarDisciplinaNoCurso(int idCurso, int idDisciplina)
        {
            var cursoDisciplina = await _cursoDisciplina.AdicionarDisciplinaNoCurso(idDisciplina, idCurso);

            var dto = _mapper.Map<CursoAndDiscplinaDTO>(cursoDisciplina);

            return Ok(dto);
        }


 
        [HttpPatch("listaDisciplinas/{idCurso}")]
        public async Task<ActionResult<CursoAndDiscplinaDTO>> AdicionarListaDisciplinasEmCurso(int idCurso, [FromBody] IEnumerable<int> idDisciplinas)
        {
            var cursoDisciplina = await _cursoDisciplina.AdicionarListaDisciplinasEmCurso(idCurso, idDisciplinas);

            var dto = _mapper.Map<CursoAndDiscplinaDTO>(cursoDisciplina);

            return Ok(dto);
        }

    }
}
