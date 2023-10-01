using API.Extensions;
using API.Middleware;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

   builder.Services.AddControllers(opt =>
    {
        var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        opt.Filters.Add(new AuthorizeFilter(policy));//svaki endpoint ce ovim zahtevati autentikaciju
    });
   
   
    builder.Services.AddApplicationServices(builder.Configuration);
    builder.Services.AddIdentityServices(builder.Configuration);
   
    // Learn more about configuring Swagger/OpenAPI at
}

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope()) 
/*
{

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "Lekar", "Sestra" };



    foreach(var role in roles)
    {

        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));

    }

}

using (var scope = app.Services.CreateScope())
{

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();


    string email = "admin@example.com";
    string email1 = "lekar@example.com";
    string email2 = "sestra@example.com";
    string password ="Pa$sword123";

    if (await userManager.FindByEmailAsync(email)==null)
    {
        var user = new AppUser
        {
            Ime = "Admir",
            UserName = "Adm",
            Email = email,
            Prezime = "Adminovic",
        };

        IdentityResult result = await userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            foreach (IdentityError error in result.Errors)
                Console.WriteLine($"Opps!{error.Description}");
        }

        await userManager.AddToRoleAsync(user, "Admin");
    }

    if (await userManager.FindByEmailAsync(email1) == null)
    {
        var user = new AppUser
        {
            Ime = "Predrag",
            UserName = "Dokon",
            Email = email1,
            Prezime = "Kon",
        };

        IdentityResult result = await userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            foreach (IdentityError error in result.Errors)
                Console.WriteLine($"Opps!{error.Description}");
        }

        await userManager.AddToRoleAsync(user, "Lekar");
    }

    if (await userManager.FindByEmailAsync(email2) == null)
    {
        var user = new AppUser
        {
            Ime = "Sestra",
            UserName = "Sestr1",
            Email = email2,
            Prezime = "Sestric",
        };

        IdentityResult result = await userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            foreach (IdentityError error in result.Errors)
                Console.WriteLine($"Opps!{error.Description}");
        }


       
        await userManager.AddToRoleAsync(user, "Sestra");

        
    }

}

using var scope2 = app.Services.CreateScope();
var services = scope2.ServiceProvider;
var userManager2 = scope2.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

var userApp = new AppUser
{
    Ime = "Sestra",
    UserName = "Sestr1",
    Email = "sestra@example.com",
    Prezime = "Sestric",

};
var uloge = userManager2.GetRolesAsync(userApp);
var Sestra = userManager2.IsInRoleAsync(userApp, "Sestra");


try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    await context.Database.MigrateAsync();
    
    await Seed.SeedData(context,userManager);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");

}
*/


app.Run();


