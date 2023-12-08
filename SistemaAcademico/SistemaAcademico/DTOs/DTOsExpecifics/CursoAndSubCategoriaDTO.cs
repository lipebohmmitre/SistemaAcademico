using SistemaAcademico.Models;

namespace SistemaAcademico.DTOs.DTOsExpecifics
{
    public class CursoAndSubCategoriaDTO
    {
        public int CursoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public SubCategoriaAndCategoriaDTO? SubCategoria { get; set; }
    }
}
