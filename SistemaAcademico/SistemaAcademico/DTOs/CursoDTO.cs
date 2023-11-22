using SistemaAcademico.Models;

namespace SistemaAcademico.DTOs
{
    public class CursoDTO
    {
        public int CursoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int SubCategoriaId { get; set; }
    }
}
