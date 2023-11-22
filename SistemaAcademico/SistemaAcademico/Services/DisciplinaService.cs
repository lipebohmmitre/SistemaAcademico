using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Repository;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Services
{
    public class DisciplinaService : Repository<Disciplina>, IDisciplina
    {
        public DisciplinaService(SistemaAcademicoDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Disciplina>> AddListDisciplinas(IEnumerable<Disciplina> disciplinaList)
        {

            foreach(var item in disciplinaList)
            {
                await base.AddAsync(item);
            }

            return disciplinaList;
        }
    }
}
