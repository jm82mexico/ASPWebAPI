using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Dominio;
using Persitencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Cursos
{
    public class Consulta
    {
        public class ListarCursos : IRequest<List<Curso>> { }
        public class Manejador : IRequestHandler<ListarCursos, List<Curso>>
        {
            private readonly CursosOnlineContext context;

            public Manejador(CursosOnlineContext _context)
            {
                context = _context;
            }

            public async Task<List<Curso>> Handle(ListarCursos request, CancellationToken cancellationToken)
            {
                var cursos = await context.Curso.ToListAsync();

                return cursos;
            }
        }
    }

}