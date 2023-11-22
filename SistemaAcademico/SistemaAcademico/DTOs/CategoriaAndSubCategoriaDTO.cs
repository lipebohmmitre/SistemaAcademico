namespace SistemaAcademico.DTOs
{
    public class CategoriaAndSubCategoriaDTO
    {
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public ICollection<SubCategoriaDTO>? SubCategorias { get; set; }
    }
}
