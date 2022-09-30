using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persitencia.DapperConexion.Instructor
{
    public interface IInstructor
    {
        Task<IEnumerable<InstructorModel>> ObtenerLista();

        Task<InstructorModel> ObtenerPorId(Guid id);

        Task<int> Nuevo(InstructorModel parametros);

        Task<int> Actualizar(InstructorModel parametros);

        Task<int> Eliminar(Guid id);
    }
}