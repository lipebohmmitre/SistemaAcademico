using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Services
{
    public class DisciplinaService : IDisciplina
    {

        private readonly SistemaAcademicoDbContext _context;

        public DisciplinaService(SistemaAcademicoDbContext context)
        {
            _context = context;
        }


        public async Task<Disciplina> Create(Disciplina disciplina)
        {
            await _context.Disciplinas.AddAsync(disciplina);
            await _context.SaveChangesAsync();

            return disciplina;
        }

        public async Task<bool> Delete(int id)
        {
            var disciplina = await _context.Disciplinas.FindAsync(id);

            if (disciplina is null) return false;

            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Disciplina>> Get()
        {
            return await _context.Disciplinas.AsNoTracking().ToListAsync();
        }

        public async Task<Disciplina> GetById(int id)
        {
            var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(p => p.DisciplinaId == id);

            if (disciplina is null) return null;

            return disciplina;
        }

        public async Task<Disciplina> Update(int id, Disciplina disciplina)
        {
            var disciplinaById = await _context.Disciplinas.FindAsync(id);

            if (disciplinaById is null) return null;

            disciplinaById.Nome = disciplina.Nome;
            disciplinaById.CargaHoraria = disciplina.CargaHoraria;
            disciplinaById.TipoDisciplina = disciplina.TipoDisciplina;

            _context.Disciplinas.Update(disciplinaById);
            await _context.SaveChangesAsync();

            return disciplinaById;
        }
    }
}
