using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Persitencia;
using MediatR;
using Aplicacion.ManejadorError;
using System.Net;

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

                if (curso == null)
                {
                    // !SE SUSTITUYE POR EL MIDDLEWARE DE MANEJO DE ERRORES PERSONALIZADO
                    // throw new Exception("No se pudo eliminar el curso");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound,
                    new { mensaje = "No se encontró el curso" });

                }

                return curso;
            }
        }
    }
}