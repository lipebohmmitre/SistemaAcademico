using SistemaAcademico.Models;

namespace SistemaAcademico.DTOs
{
    public class CategoriaDTO
    {
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
