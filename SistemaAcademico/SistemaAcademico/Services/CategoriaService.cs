using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Services
{
    public class CategoriaService : ICategoria
    {

        private readonly SistemaAcademicoDbContext _context;

        public CategoriaService(SistemaAcademicoDbContext context)
        {
            _context = context;
        }


        public async Task<Categoria> Create(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<bool> Delete(int id)
        {
            var categoriaById = await _context.Categorias.FindAsync(id);

            if (categoriaById is null) return false;

            _context.Categorias.Remove(categoriaById);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Categoria>> Get()
        {
            // Utilizando o método AsNoTracking para ganho de performace
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<Categoria> GetById(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(p => p.CategoriaId == id);

            if (categoria is null) return null;

            return categoria;
        }

        public async Task<Categoria> GetCategoriaAndSubCategoria(int id)
        {
            var categoriaAndSub = await _context.Categorias.Include(p => p.SubCategorias).AsNoTracking().FirstOrDefaultAsync(p => p.CategoriaId == id);

            if (categoriaAndSub is null) return null;

            return categoriaAndSub;
        }

        public async Task<Categoria> Update(int id, Categoria categoria)
        {
            var categoriaById = await _context.Categorias.FirstOrDefaultAsync(p => p.CategoriaId == id);

            if (categoriaById is null) return null;

            categoriaById.Nome = categoria.Nome;
            categoriaById.Descricao = categoria.Descricao;

            _context.Categorias.Update(categoriaById);
            await _context.SaveChangesAsync();

            return categoriaById;
        }
    }
}
