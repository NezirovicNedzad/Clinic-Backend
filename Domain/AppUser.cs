﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AppUser :IdentityUser
    {


        public string Ime { get; set; }
        public string Prezime { get; set; }


        
    }
}
