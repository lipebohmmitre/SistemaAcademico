using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Models;

namespace SistemaAcademico.Repository.InterfacesRepository
{
    public interface ICursoDisciplinaRepository
    {
        Task<Curso> GetCursoAndDisciplina(int idCurso);
        Task<Curso> AdicionarDisciplinaNoCurso(int idDisciplina, int idCurso);
        Task<Curso> AdicionarListaDisciplinasEmCurso(int idCurso, [FromBody] IEnumerable<int> idDisciplinas);
    }
}
