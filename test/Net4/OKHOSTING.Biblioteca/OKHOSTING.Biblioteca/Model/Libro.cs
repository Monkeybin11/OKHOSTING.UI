using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.Biblioteca.Model
{
    public class Libro
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Autor Autor { get; set; }

        public Editorial Editorial { get; set; }
    }
}
