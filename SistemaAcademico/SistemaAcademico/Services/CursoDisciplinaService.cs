using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Repository;
using SistemaAcademico.Services.Interfaces;

namespace SistemaAcademico.Services
{
    public class CursoDisciplinaService : CursoDisciplinaRepository, ICursoDisciplina
    {
        public CursoDisciplinaService(SistemaAcademicoDbContext context) : base(context)
        {
        }
    }
}
