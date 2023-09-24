﻿using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataContext :IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

      
       
       public DbSet<Odeljenje>Odeljenja { get; set; } 
    



public DbSet<Karton> Kartoni{get;set;}
       public DbSet<Pacijent>Pacijenti{get; set;}


       public DbSet<Pregled>Pregledi{get;set;}

       public DbSet<Napomena>Napomene{get; set;}
  
  protected override void  OnModelCreating(ModelBuilder builder)
  {

builder.Entity<IdentityUserLogin<string>>().HasNoKey();


builder.Entity<IdentityUserToken<string>>().HasNoKey();


builder.Entity<IdentityUserRole<string>>().HasNoKey();



builder.Entity<Pacijent>().HasMany(x=>x.Kartoni).WithOne(p=>p.Pacijent).OnDelete(DeleteBehavior.Cascade);

builder.Entity<Karton>().HasMany(x=>x.Pregledi).WithOne(p=>p.Karton).OnDelete(DeleteBehavior.Cascade);

builder.Entity<Karton>().HasMany(x=>x.Nampomene).WithOne(p=>p.Karton).OnDelete(DeleteBehavior.Cascade);



  
  
  }
  



     


    }
}
