using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Repository;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Services
{
    public class CursoService : CursoRepository, ICurso
    {
        public CursoService(SistemaAcademicoDbContext context) : base(context)
        {
        }

    }
}
