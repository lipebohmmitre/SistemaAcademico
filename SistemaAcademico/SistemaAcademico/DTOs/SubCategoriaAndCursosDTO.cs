namespace SistemaAcademico.DTOs
{
    public class SubCategoriaAndCursosDTO
    {
        public int SubCategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int CategoriaId { get; set; }
        public ICollection<CursoDTO>? Cursos { get; set; }
    }
}
