using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
      
        public string Role { get; set; }
      
        public string Specijalizacija { get; set; }
      
        public Odeljenje Odeljenje {get; set;}
        public ICollection<Karton> Kartoni {get; set;}
        public ICollection<Pregled> Pregledi{get; set;}
    }
}
