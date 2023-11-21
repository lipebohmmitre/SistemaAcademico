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
    }
}
