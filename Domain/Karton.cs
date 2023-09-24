using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Domain
{
    public class Karton
    {

        public Guid Id{get; set;}
        
        public string Dijagnoza {get; set;}

        public string Terapija {get;set;}

        public AppUser Lekar  {get; set;}

        public Odeljenje Odeljenje {get; set;}

        public Pacijent Pacijent{get;set;}

public ICollection<Pregled> Pregledi{get; set;}


public ICollection<Napomena> Nampomene {get;set;}
    }
}