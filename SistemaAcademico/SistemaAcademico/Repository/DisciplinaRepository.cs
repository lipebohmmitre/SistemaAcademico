using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Repository.InterfacesRepository;

namespace SistemaAcademico.Repository
{
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(SistemaAcademicoDbContext context) : base(context)
        {
        }
    }
}
