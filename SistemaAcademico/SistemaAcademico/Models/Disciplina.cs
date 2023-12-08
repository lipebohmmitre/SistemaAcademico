using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAcademico.Models
{
    public class Disciplina
    {

        public Disciplina()
        {
            Cursos = new List<Curso>();
        }


        public int DisciplinaId { get; set; }
        public string? Nome {  get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal CargaHoraria { get; set; }
        public string? TipoDisciplina { get; set; }


        public ICollection<Curso>? Cursos { get; set; }
    }
}
