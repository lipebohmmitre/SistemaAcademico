using System.Text.Json.Serialization;

namespace SistemaAcademico.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }



        public int SubCategoriaId { get; set; }
        [JsonIgnore]
        public SubCategoria? SubCategoria { get; set; }
    }
}
