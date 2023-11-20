using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Models;

namespace SistemaAcademico.Services.Interfaces
{
    public interface IDisciplina
    {
        Task<IEnumerable<Disciplina>> Get();
        Task<Disciplina> GetById(int id);
        Task<Disciplina> Create(Disciplina disciplina);
        Task<Disciplina> Update(int id, Disciplina disciplina);
        Task<bool> Delete(int id);
    }
}
