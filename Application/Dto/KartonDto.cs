using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Application.Dto
{
    public class KartonDto
    {
        public Guid Id { get; set; }

        public string Terapija { get; set; }

        public string Dijagnoza {get;set;}

        public ICollection<PregledDto2> Pregledi {get; set;}
 
        public LekarDto Lekar {get; set;}
 
    }
}