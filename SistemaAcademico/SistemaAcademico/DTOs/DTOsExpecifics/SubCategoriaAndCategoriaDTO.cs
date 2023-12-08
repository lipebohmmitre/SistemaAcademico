using SistemaAcademico.Models;

namespace SistemaAcademico.DTOs.DTOsExpecifics
{
    public class SubCategoriaAndCategoriaDTO
    {
        public int SubCategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        public CategoriaDTO? Categoria { get; set; }
    }
}
