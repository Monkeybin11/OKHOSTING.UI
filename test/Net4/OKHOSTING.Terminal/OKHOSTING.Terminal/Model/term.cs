using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.Terminal.Model
{
    class Pasajero
    {
        public Guid id { get; set; }

        public string Direccion  {get; set;}

        public string Encargado { get; set; }

        public Autobus Matricula { get; set; }


        public override string ToString()
        {
            return Direccion;
        }

    }
}
