namespace SistemaAcademico.DTOs
{
    public class CursoAndDiscplinaDTO
    {
        public int CursoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int SubCategoriaId { get; set; }
        public ICollection<DisciplinaDTO> Disciplinas { get; set;}
    }
}
