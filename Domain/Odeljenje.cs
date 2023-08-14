using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Odeljenje
    {



        public Guid Id { get; set; }

        public string Naziv { get; set; }

        public int BrojKreveta { get; set; }

        public int BrojPacijenata { get; set; }
    }
}
