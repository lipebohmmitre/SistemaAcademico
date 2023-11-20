using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Models;

namespace SistemaAcademico.Services.Interfaces
{
    public interface ISubCategoria
    {
        Task<IEnumerable<SubCategoria>> Get();
        Task<SubCategoria> GetById(int id);
        Task<SubCategoria> GetSubCategoriaAndCurso(int id);
        Task<SubCategoria> Create(SubCategoria subCategoria);
        Task<SubCategoria> Update(int id, SubCategoria subCategoria);
        Task<bool> Delete(int id);
    }
}
