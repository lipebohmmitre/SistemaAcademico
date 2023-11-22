using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Repository;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Services
{
    public class SubCategoriaService : Repository<SubCategoria>, ISubCategoria
    {
        public SubCategoriaService(SistemaAcademicoDbContext context) : base(context)
        {
        }


        public async Task<SubCategoria> GetSubCategoriaAndCurso(int id)
        {
            var subCategoria = await _context.SubCategorias.Include(p => p.Cursos).SingleOrDefaultAsync(p => p.SubCategoriaId == id);

            if (subCategoria is null) return null;

            return subCategoria;
        }
    }
}
