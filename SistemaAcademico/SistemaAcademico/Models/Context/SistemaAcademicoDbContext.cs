using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SistemaAcademico.Models.Context
{
    public class SistemaAcademicoDbContext : IdentityDbContext
    {
        public SistemaAcademicoDbContext(DbContextOptions<SistemaAcademicoDbContext> options) : base(options) {}

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set;}
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
    }
}
