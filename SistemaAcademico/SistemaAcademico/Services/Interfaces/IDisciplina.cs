using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Models;
using SistemaAcademico.Repository.InterfacesRepository;

namespace SistemaAcademico.Services.Interfaces
{
    public interface IDisciplina : IDisciplinaRepository
    {
        Task<IEnumerable<Disciplina>> AddListDisciplinas(IEnumerable<Disciplina> disciplinaList);
    }
}
