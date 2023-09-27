using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Dto
{
    public class KartonDtoIstorija
    {
         public Guid IdK { get; set; }

      public Guid IdPacijenta{get;set;}

public Guid IdOdeljenja{get; set;}
public string NazivOdeljenja{get;set;}
   public string ImeLekara{get; set;}

   public string PrezimeLekara{get; set;}
      

        
    }
}