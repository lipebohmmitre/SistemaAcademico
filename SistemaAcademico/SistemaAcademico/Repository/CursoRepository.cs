using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Repository.InterfacesRepository;

namespace SistemaAcademico.Repository
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(SistemaAcademicoDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Curso>> GetCursosSubCategoriasAndCategorias()
        {
            return await _context.Cursos.Include(s => s.SubCategoria)
                .ThenInclude(c => c.Categoria).AsNoTracking().ToListAsync();
        }
    }
}
