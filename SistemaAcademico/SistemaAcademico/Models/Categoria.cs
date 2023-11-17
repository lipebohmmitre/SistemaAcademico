namespace SistemaAcademico.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }


        public ICollection<SubCategoria>? SubCategorias { get; set;}
    }
}
