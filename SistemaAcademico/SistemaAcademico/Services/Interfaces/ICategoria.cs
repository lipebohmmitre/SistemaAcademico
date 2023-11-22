using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Models;
using SistemaAcademico.Repository.InterfacesRepository;

namespace SistemaAcademico.Services.Interfaces
{
    public interface ICategoria : ICategoriaRepository
    {
        Task<Categoria> GetCategoriaAndSubCategoria(int id);
       
    }
}
