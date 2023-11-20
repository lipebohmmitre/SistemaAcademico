using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Models;

namespace SistemaAcademico.Services.Interfaces
{
    public interface ICurso
    {
        Task<IEnumerable<Curso>> Get();
        Task<Curso> GetById(int id);
        Task<Curso> Create(Curso curso);
        Task<Curso> Update(int id, Curso curso);
        Task<bool> Delete(int id);
    }
}
