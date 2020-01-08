using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.Cine.Model
{
  public class Persona
    {
        public Guid id { get; set; }

       public Pelicula NombrePelicula { get; set; }
       
        public Sala NumeroSala { get; set; }

        public Sala HoraFuncion { get; set; }

    }
}
