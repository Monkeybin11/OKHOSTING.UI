using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.Terminal.Model
{
    public class Autobus
    { 
        public Guid Id { get; set; }

        public string Matricula { get; set; }

        public string Numero { get; set; }

        public override string ToString()
        {
            return Matricula;
        }
    }
}
