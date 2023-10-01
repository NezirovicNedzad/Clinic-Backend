using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Dto
{
    public class PacijentDto2
    {
                public Guid Id {get; set;
        }
        public string Ime { get; set; }
        public string Prezime { get; set; }   

        public string JMBG {get; set;}
        
        public int BrojGodina{get;set;}
        public string Pol{get;set;}

    
        
        public string ImeLekara{get;set;}
         public string PrezimeLekara{get;set;}
         public string UsernameLekara{get;set;}
        public string IdLekara{get;set;}
        public Guid IdOdeljenja{get;set;}
public string NazivOdeljenja{get;set;}        
    }
}