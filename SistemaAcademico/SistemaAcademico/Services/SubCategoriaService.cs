using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Services
{
    public class SubCategoriaService : ISubCategoria
    {

        private readonly SistemaAcademicoDbContext _context;

        public SubCategoriaService(SistemaAcademicoDbContext context)
        {
            _context = context;
        }


        public async Task<SubCategoria> Create(SubCategoria subCategoria)
        {
            await _context.SubCategorias.AddAsync(subCategoria);
            await _context.SaveChangesAsync();

            return subCategoria;
        }

        public async Task<bool> Delete(int id)
        {
            var subCategoria = await _context.SubCategorias.FindAsync(id);

            if (subCategoria is null) return false;

            _context.SubCategorias.Remove(subCategoria);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<SubCategoria>> Get()
        {
            // Utilizando o método AsNoTracking para ganho de performace
            var subCategoria = await _context.SubCategorias.AsNoTracking().ToListAsync();
            return subCategoria;
        }

        public async Task<SubCategoria> GetById(int id)
        {
            var subCategoria = await _context.SubCategorias.AsNoTracking().FirstOrDefaultAsync(p => p.SubCategoriaId == id);

            if (subCategoria is null) return null;

            return subCategoria;
        }

        public async Task<SubCategoria> GetSubCategoriaAndCurso(int id)
        {
            var subCategoria = await _context.SubCategorias.Include(p => p.Cursos).SingleOrDefaultAsync(p => p.SubCategoriaId == id);

            if (subCategoria is null) return null;

            return subCategoria;
        }

        public async Task<SubCategoria> Update(int id, SubCategoria subCategoria)
        {
            var subCategoriaById = await _context.SubCategorias.FindAsync(id);

            if (subCategoriaById is null) return null;

            subCategoriaById.Nome = subCategoria.Nome;
            subCategoriaById.Descricao = subCategoria.Descricao;
            subCategoriaById.CategoriaId = subCategoria.CategoriaId;

            _context.SubCategorias.Update(subCategoriaById);
            await _context.SaveChangesAsync();

            return subCategoriaById;
        }
    }
}
