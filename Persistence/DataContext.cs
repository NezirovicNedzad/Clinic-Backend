using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

 base.OnModelCreating(builder);

        
            builder.Entity<IdentityRole>()
                    .HasData(
                        new IdentityRole { Name = "Lekar", NormalizedName = "LEKAR" },
                        new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },    
                        new IdentityRole { Name = "Sestra", NormalizedName = "SESTRA" }
                    );



        builder.Entity<Karton>().HasMany(x=>x.Pregledi).WithOne(p=>p.Karton).OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Karton>().HasMany(x=>x.Nampomene).WithOne(p=>p.Karton).OnDelete(DeleteBehavior.Cascade);

        }







    }
}
