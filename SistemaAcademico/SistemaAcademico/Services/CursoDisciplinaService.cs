using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Services
{
    public class CursoDisciplinaService : ICursoDisciplina
    {

        private readonly SistemaAcademicoDbContext _context;

        public CursoDisciplinaService(SistemaAcademicoDbContext context)
        {
            _context = context;
        }



        public async Task<Curso> GetCursoAndDisciplina(int idCurso)
        {
            var curso = await _context.Cursos.Include(p => p.Disciplinas).AsNoTracking().FirstOrDefaultAsync(p => p.CursoId == idCurso);
            return curso;
        }


        public async Task<Disciplina> AdicionarCursoNaDisciplina(int idDisciplina, int idCurso)
        {
            Disciplina disciplina = await _context.Disciplinas.FirstOrDefaultAsync(p => p.DisciplinaId == idDisciplina);
            Curso curso = await _context.Cursos.FirstOrDefaultAsync(p => p.CursoId == idCurso);

            if (disciplina is null || curso is null) return null;

            disciplina.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return disciplina;
        }

        public async Task<Curso> AdicionarListaDisciplinasEmCurso(int idCurso, [FromBody] IEnumerable<int> idDisciplinas)
        {
            var curso = await _context.Cursos.FirstOrDefaultAsync(p => p.CursoId == idCurso);
            List<Disciplina> disciplinasList = new List<Disciplina>();

            foreach (var item in idDisciplinas)
            {
                var disciplinaById = await _context.Disciplinas.FirstOrDefaultAsync(p => p.DisciplinaId == item);
                disciplinasList.Add(disciplinaById);
            }

            foreach (var item in disciplinasList)
            {
                curso.Disciplinas.Add(item);

            }
            await _context.SaveChangesAsync();
            return curso;
        }
    }
}
