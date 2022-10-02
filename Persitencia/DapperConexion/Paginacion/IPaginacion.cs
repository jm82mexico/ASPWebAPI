using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persitencia.DapperConexion.Paginacion
{
    public interface IPaginacion
    {
        Task<PaginacionModel> devolverPaginacion(
            string storeProcedure,
            int numeroPagina,
            int cantidadElementos,
            IDictionary<string, object> parametrosFiltro,
            string ordenamientoColumna
        );
    }
}