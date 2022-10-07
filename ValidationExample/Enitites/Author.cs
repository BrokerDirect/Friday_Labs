using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationExample.Enitites
{
    internal record Author
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }

    }
}
