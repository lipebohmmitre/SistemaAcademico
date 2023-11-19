using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Models;

namespace SistemaAcademico.Services.Interfaces
{
    public interface ICategoria
    {
        Task<IEnumerable<Categoria>> Get();
        Task<Categoria> GetById(int id);
        Task<Categoria> GetCategoriaAndSubCategoria(int id);
        Task<Categoria> Create(Categoria categoria);
        Task<Categoria> Update(int id,  Categoria categoria);
        Task<bool> Delete(int id);
    }
}
