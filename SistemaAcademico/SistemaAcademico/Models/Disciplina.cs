using Microsoft.AspNetCore.Authentication;

namespace SistemaAcademico.Models
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string? Nome {  get; set; }
        public decimal CargaHoraria { get; set; }
        public string? TipoDisciplina { get; set; }


        public ICollection<Curso>? Cursos { get; set; }
    }
}
