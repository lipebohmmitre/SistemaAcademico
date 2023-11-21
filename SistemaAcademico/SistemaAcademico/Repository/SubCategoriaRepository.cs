using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Repository.InterfacesRepository;

namespace SistemaAcademico.Repository
{
    public class SubCategoriaRepository : Repository<SubCategoria>, ISubCategoriaRepository
    {
        public SubCategoriaRepository(SistemaAcademicoDbContext context) : base(context)
        {
        }
    }
}
