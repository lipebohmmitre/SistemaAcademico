using System.Text.Json.Serialization;

namespace SistemaAcademico.Models
{
    public class SubCategoria
    {
        public int SubCategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }


        public int CategoriaId { get; set; }
        [JsonIgnore]
        public Categoria? Categoria { get; set; }


        public ICollection<Curso>? Cursos { get; set; }
    }
}
