using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Models;

namespace SistemaAcademico.Services.Interfaces
{
    public interface ICursoDisciplina
    {
        Task<Curso> GetCursoAndDisciplina(int idCurso);
        Task<Disciplina> AdicionarCursoNaDisciplina(int idDisciplina, int idCurso);
        Task<Curso> AdicionarListaDisciplinasEmCurso(int idCurso, [FromBody] IEnumerable<int> idDisciplinas);
    }
}
