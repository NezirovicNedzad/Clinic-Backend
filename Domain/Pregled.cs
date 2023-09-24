using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Pregled
    {

        public Guid Id { get; set; }


        public string Anamneza {get; set;}

        public string Dijagnoza { get; set; }

        public DateTime VremePregleda{get;set;}

        public string Terapija {get; set;}
   
        public Karton Karton {get; set;}
        public AppUser Lekar {get; set;}
        
    }
}