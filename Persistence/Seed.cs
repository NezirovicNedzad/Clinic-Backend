using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context,UserManager<AppUser> userManager)
        {



            var users = new List<AppUser>
                {

                    new AppUser
                    {


                        Ime="Nedzad",
                        UserName="bob",
                        Email="bob@example",
                        Prezime="Nezirovic"

                    },
                    new AppUser
                    {


                        Ime="Leo",
                        UserName="leo",
                        Email="leo@example.com",
                        Prezime="Messi",
                 
                    
                    },




            
                };

                foreach (var user in users)
                {
                IdentityResult result= await userManager.CreateAsync(user, "Pas$word123");
                   if(!result.Succeeded)
                {
                    foreach (IdentityError error in result.Errors)
                        Console.WriteLine($"Opps!{error.Description}");
                }
                }

               

            
            if (context.Odeljenja.Any()) return;

            var activities = new List<Odeljenje>
            {
                new Odeljenje
                {
                   Id=Guid.NewGuid(),
                   Naziv="Pedijatrija",
                   BrojKreveta=25,
                   BrojPacijenata=2
                },
                    new Odeljenje
                {
                   Id=Guid.NewGuid(),
                   Naziv="Ortopedija",
                   BrojKreveta=23,
                   BrojPacijenata=2
                },

    };

            await context.Odeljenja.AddRangeAsync(activities);
            await context.SaveChangesAsync();

        }
    }
}