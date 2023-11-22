using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Repository;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Services
{
    public class CategoriaService : Repository<Categoria>, ICategoria
    {
        public CategoriaService(SistemaAcademicoDbContext context) : base(context)
        {
        }


        public async Task<Categoria> GetCategoriaAndSubCategoria(int id)
        {
            var categoriaAndSub = await _context.Categorias.Include(p => p.SubCategorias).AsNoTracking().FirstOrDefaultAsync(p => p.CategoriaId == id);

            if (categoriaAndSub is null) return null;

            return categoriaAndSub;
        }

    }
}
