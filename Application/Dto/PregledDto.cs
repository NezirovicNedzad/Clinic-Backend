using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class PregledDto
    {
         public Guid Id { get; set; }


        public string Anamneza {get; set;}

        public string Dijagnoza { get; set; }


        public string Terapija {get; set;}
       
        public Guid  IdKarton {get; set;}
        public string IdLekar {get; set;}
    }
}