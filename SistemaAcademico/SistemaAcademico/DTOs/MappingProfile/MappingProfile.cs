using AutoMapper;
using SistemaAcademico.DTOs.DTOsExpecifics;
using SistemaAcademico.Models;

namespace SistemaAcademico.DTOs.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaAndSubCategoriaDTO>().ReverseMap();
            CreateMap<SubCategoria, SubCategoriaDTO>().ReverseMap();
            CreateMap<SubCategoria, SubCategoriaAndCursosDTO>().ReverseMap();
            CreateMap<Curso, CursoDTO>().ReverseMap();
            CreateMap<Curso, CursoAndDiscplinaDTO>().ReverseMap();
            CreateMap<Disciplina, DisciplinaDTO>().ReverseMap();

            CreateMap<Curso, CursoAndSubCategoriaDTO>().ReverseMap();
            CreateMap<SubCategoria, SubCategoriaAndCategoriaDTO>().ReverseMap();
        }
    }
}
