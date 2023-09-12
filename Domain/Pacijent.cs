using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Pacijent
    {
        public Guid Id{get; set;}
        public string Ime { get; set; }
        public string Prezime { get; set; }   

        public string JMBG {get; set;}
        
        public int BrojGodina{get;set;}
        public string Pol{get;set;}
       public Odeljenje Odeljenje{get; set;}
        
        public ICollection<Karton> Kartoni {get;set;}
    }
}