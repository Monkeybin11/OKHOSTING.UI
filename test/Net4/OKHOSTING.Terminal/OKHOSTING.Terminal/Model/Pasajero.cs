using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.Terminal.Model
{
    class Terminal
    {
         public Guid Id { set; get; }

         public Autobus Matricula { set; get; } 

         public string Nombre { set; get; }

        public Pasajero Direccion { set; get; }

    }
}
