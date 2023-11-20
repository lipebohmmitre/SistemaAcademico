using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Services
{
    public class CursoService : ICurso
    {

        private readonly SistemaAcademicoDbContext _context;

        public CursoService(SistemaAcademicoDbContext context)
        {
            _context = context;
        }


        public async Task<Curso> Create(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();

            return curso;
        }

        public async Task<bool> Delete(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso is null) return false;

            return true;
        }

        public async Task<IEnumerable<Curso>> Get()
        {
            var cursos = await _context.Cursos.AsNoTracking().ToListAsync();
            return cursos;
        }

        public async Task<Curso> GetById(int id)
        {
            var curso = await _context.Cursos.AsNoTracking().FirstOrDefaultAsync(p => p.CursoId == id);

            if (curso is null) return null;

            return curso;
        }

        public async Task<Curso> Update(int id, Curso curso)
        {
            var cursoById = await _context.Cursos.FindAsync(id);

            if (cursoById is null) return null;

            cursoById.Nome = curso.Nome;
            cursoById.Descricao = curso.Descricao;
            cursoById.SubCategoriaId = curso.SubCategoriaId;

            _context.Cursos.Update(cursoById);
            await _context.SaveChangesAsync();

            return cursoById;
        }
    }
}
