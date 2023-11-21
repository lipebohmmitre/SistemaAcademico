using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Repository.InterfacesRepository;

namespace SistemaAcademico.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(SistemaAcademicoDbContext context) : base(context)
        {
        }
    }
}
