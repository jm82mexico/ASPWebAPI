using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Persitencia;
using MediatR;
using System.Net;
using Aplicacion.ManejadorError;

namespace Aplicacion.Cursos
{
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            public Guid CursoId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CursosOnlineContext context;

            public Manejador(CursosOnlineContext _context)
            {
                context = _context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var instructoresDB = context.CursoInstructor.Where(x => x.CursoId == request.CursoId);

                foreach (var instructor in instructoresDB)
                {
                    context.CursoInstructor.Remove(instructor);
                }

                var curso = await context.Curso.FindAsync(request.CursoId);

                if (curso == null)
                {
                    // !SE SUSTITUYE POR EL MIDDLEWARE DE MANEJO DE ERRORES PERSONALIZADO
                    // throw new Exception("No se pudo eliminar el curso");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound,
                    new { mensaje = "No se encontró el curso" });

                }

                context.Remove(curso);

                var resultado = context.SaveChanges();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudieron guardar los cambios");
            }
        }
    }
}