using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Dominio;
using Persitencia;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Aplicacion.Cursos
{
    public class Consulta
    {
        public class ListarCursos : IRequest<List<CursoDto>> { }
        public class Manejador : IRequestHandler<ListarCursos, List<CursoDto>>
        {
            private readonly CursosOnlineContext _context;
            private readonly IMapper _mapper;

            public Manejador(CursosOnlineContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CursoDto>> Handle(ListarCursos request, CancellationToken cancellationToken)
            {
                var cursos = await _context.Curso
                    .Include(x => x.ComentarioLista)
                    .Include(x => x.Promocion)
                    .Include(x => x.InstructoresLink)
                    .ThenInclude(x => x.Instructor).ToListAsync();

                var cursoDto = _mapper.Map<List<Curso>, List<CursoDto>>(cursos);

                return cursoDto;
            }
        }
    }

}