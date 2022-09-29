using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class CursoInstructorDto
    {
        public Guid InstructorId { get; set; }
        public Guid CursoId { get; set; }
    }
}