using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {





        public Guid Id { get; set; }
        public int JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
         public bool IsAdmin { get; set; }
        public bool IsDoctor{ get; set; }
        public bool IsNurse { get; set; }

        public string Specialization { get; set; }



    }
}
