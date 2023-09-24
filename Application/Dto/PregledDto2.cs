using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Dto
{
    public class PregledDto2
    {
   
         public Guid Id { get; set; }


        public string Anamneza {get; set;}

        public string Dijagnoza { get; set; }

        public DateTime VremePregleda{get;set;}
        public string Terapija {get; set;}
 
        public LekarDto Lekar  {get; set;}
    
        
    }
}