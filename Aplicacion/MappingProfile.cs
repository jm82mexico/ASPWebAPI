using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Cursos;
using AutoMapper;
using Dominio;

namespace Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Curso, CursoDto>()
            // * QUE PROPPIEDAD CURSODTO VA A LLENAR 
            // * public ICollection<InstructorDto> Instructores { get; set; }
            .ForMember(x => x.Instructores,
            // *  A TRAVEZ DE QUE PROPIEDAD CURSO DE LA PROYECTO DOMINIO
            // * public ICollection<CursoInstructor> InstructoresLink { get; set; }
             y => y.MapFrom(z => z.InstructoresLink
             //  * QUE ES LO QUE VA A DEVOLVER
             .Select(a => a.Instructor).ToList()));
            CreateMap<CursoInstructor, CursoInstructorDto>();
            CreateMap<Instructor, InstructorDto>();
        }
    }
}