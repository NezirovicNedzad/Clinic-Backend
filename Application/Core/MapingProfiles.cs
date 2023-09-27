using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class MapingProfiles :Profile
    {



        public MapingProfiles()
        {
            CreateMap<Odeljenje,Odeljenje>();


        CreateMap<Pacijent,Pacijent>();
        }


    }
}
