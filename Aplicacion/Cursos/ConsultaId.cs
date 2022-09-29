using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Persitencia;
using MediatR;
using Aplicacion.ManejadorError;
using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Cursos
{
    public class ConsultaId
    {
        public class CursoUnico : IRequest<CursoDto>
        {
            public Guid Id { get; set; }
        }

        public class Maanejador : IRequestHandler<CursoUnico, CursoDto>
        {
            private readonly CursosOnlineContext context;
            private readonly IMapper _mapper;
            public Maanejador(CursosOnlineContext _context, IMapper mapper)
            {
                context = _context;
                _mapper = mapper;
            }

            public async Task<CursoDto> Handle(CursoUnico request, CancellationToken cancellationToken)
            {
                var curso = await context.Curso
                .Include(x => x.InstructoresLink)
                .ThenInclude(y => y.Instructor)
                .FirstOrDefaultAsync(a => a.CursoId == request.Id);


                if (curso == null)
                {
                    // !SE SUSTITUYE POR EL MIDDLEWARE DE MANEJO DE ERRORES PERSONALIZADO
                    // throw new Exception("No se pudo eliminar el curso");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound,
                    new { mensaje = "No se encontró el curso" });

                }

                var cursoDto = _mapper.Map<Curso, CursoDto>(curso);

                return cursoDto;
            }
        }
    }
}