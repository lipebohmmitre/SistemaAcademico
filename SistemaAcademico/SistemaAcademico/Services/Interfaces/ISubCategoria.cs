using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Models;
using SistemaAcademico.Repository.InterfacesRepository;

namespace SistemaAcademico.Services.Interfaces
{
    public interface ISubCategoria : ISubCategoriaRepository
    {
        Task<SubCategoria> GetSubCategoriaAndCurso(int id);
    }
}
