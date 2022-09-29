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
            // CreateMap<Curso, CursoDto>()
            // * QUE PROPPIEDAD CURSODTO VA A LLENAR 
            // * public ICollection<InstructorDto> Instructores { get; set; }
            // .ForMember(x => x.Instructores,
            // *  A TRAVEZ DE QUE PROPIEDAD CURSO DE LA PROYECTO DOMINIO
            // * public ICollection<CursoInstructor> InstructoresLink { get; set; }
            //  y => y.MapFrom(z => z.InstructoresLink
            //  * QUE ES LO QUE VA A DEVOLVER
            //  .Select(a => a.Instructor).ToList()))
            //  .ForMember(x => x.Comentarios, y => y.MapFrom(z => z.ComentarioLista))
            //  .ForMember(x => x.Precio, y => y.MapFrom(y => y.Precio));

            // + Mapeo muchos a muchos
            CreateMap<Curso, CursoDto>().ForMember(x => x.Instructores,
            y => y.MapFrom(z => z.InstructoresLink
            .Select(a => a.Instructor).ToList()))
            // + Mapeo uno a muchos
            .ForMember(x => x.Comentarios, y => y.MapFrom(z => z.ComentarioLista))
            // + Mapeo uno a uno
            .ForMember(x => x.Precio, y => y.MapFrom(y => y.Promocion));

            CreateMap<CursoInstructor, CursoInstructorDto>();
            CreateMap<Instructor, InstructorDto>();
            CreateMap<Comentario, ComentarioDto>();
            CreateMap<Precio, PrecioDto>();
        }
    }
}