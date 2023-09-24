using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Napomena
    {
        public Guid Id{get;set ;}


        public string NezeljenoDejstvo { get; set; }
         public string Primedba { get; set; }

         public Karton Karton{get; set;}

         public AppUser Sestra {get; set;}
    }
}