using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Persitencia;
using MediatR;

namespace Aplicacion.Cursos
{
    public class ConsultaId
    {
        public class CursoUnico : IRequest<Curso>
        {
            public int Id { get; set; }
        }

        public class Maanejador : IRequestHandler<CursoUnico, Curso>
        {
            private readonly CursosOnlineContext context;

            public Maanejador(CursosOnlineContext _context)
            {
                context = _context;
            }

            public async Task<Curso> Handle(CursoUnico request, CancellationToken cancellationToken)
            {
                var curso = await context.Curso.FindAsync(request.Id);

                return curso;
            }
        }
    }
}