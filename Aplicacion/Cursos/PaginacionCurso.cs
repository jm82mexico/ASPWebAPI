using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persitencia.DapperConexion.Paginacion;

namespace Aplicacion.Cursos
{
    public class PaginacionCurso
    {
        public class Ejecuta : IRequest<PaginacionModel>
        {
            public string Titulo { get; set; }
            public int NumeroPaginas { get; set; }
            public int CantidadElementos { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, PaginacionModel>
        {
            private readonly IPaginacion _paginacion;

            public Manejador(IPaginacion paginacion)
            {
                _paginacion = paginacion;
            }
            public async Task<PaginacionModel> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var storeProcedure = "usp_obtener_curso_paginacion";
                var ordenamiento = "Titulo";
                var parametos = new Dictionary<string, object>();
                parametos.Add("NombreCurso", request.Titulo);
                return await _paginacion.devolverPaginacion(storeProcedure, request.NumeroPaginas, request.CantidadElementos, parametos, ordenamiento);
            }
        }
    }
}