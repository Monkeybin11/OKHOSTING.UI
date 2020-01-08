using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.ORM.Tests.Model
{
   public class Maestro
    {
        public Guid Id { get; set; }

        [OKHOSTING.Data.Validation.StringLengthValidator(100)]
        public string FirstName;

        [OKHOSTING.Data.Validation.StringLengthValidator(100)]
        public string LastName;

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
