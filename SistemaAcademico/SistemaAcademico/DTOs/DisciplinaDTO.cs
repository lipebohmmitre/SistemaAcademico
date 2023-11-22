using SistemaAcademico.Models;

namespace SistemaAcademico.DTOs
{
    public class DisciplinaDTO
    {
        public int DisciplinaId { get; set; }
        public string? Nome { get; set; }
        public decimal CargaHoraria { get; set; }
        public string? TipoDisciplina { get; set; }
    }
}
