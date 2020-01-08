using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.Cine.Model
{
    public class Pelicula
    {
        public Guid Id { get; set; }

        public string NombrePelicula { get; set; }

        public string Genero { get; set; }


        public override string ToString()
        {
            return NombrePelicula;
        }
    }
}
