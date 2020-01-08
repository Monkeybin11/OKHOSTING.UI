using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.Cine.Model
{
    public class Sala
    {
        public Guid Id { get; set; }

        public string NumeroSala { get; set; }
      

        public int Capaciadad { get; set; }

        public string HoraFuncion { get; set; }
        public override string ToString()
        {
            return NumeroSala;
        }
    }
}
