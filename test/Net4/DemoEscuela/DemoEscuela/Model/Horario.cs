using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.ORM.Tests.Model
{
   public class Horario
    {
        public Guid Id { get; set; }

        public Alumno Alumno { get; set; }

        public Maestro Maestro { get; set; }

        public Materia Materia { get; set; }
    }
}
