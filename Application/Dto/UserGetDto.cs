using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UserGetDto
    {
         public string Id {get;set;}
        public  string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
      
        public string Role { get; set; }
        public string Image { get; set; }
        public string Username { get; set; }
        public string Specijalizacija { get; set; }
        public string OdeljenjeId{get;set;}

    }
}