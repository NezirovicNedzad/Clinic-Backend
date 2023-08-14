using API.Extensions;
using Application.Odeljenja;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddApplicationServices(builder.Configuration);

    // Learn more about configuring Swagger/OpenAPI at
}
var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


    app.UseCors("CorsPolicy");
    app.UseAuthorization();

    app.MapControllers();

    using var scope = app.Services.CreateScope();

    var services = scope.ServiceProvider;




    app.Run();
}