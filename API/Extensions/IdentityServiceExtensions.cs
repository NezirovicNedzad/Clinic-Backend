﻿using API.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System.Text;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {

        public static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration config)
        {

            services.AddIdentityCore<AppUser>(opt =>
            {

                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = true;

            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<DataContext>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {

                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            
            });
services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireRole("Admin"));
                    options.AddPolicy("LekarOnly", policy =>
                    policy.RequireRole("Lekar"));
                    options.AddPolicy("SestraOnly", policy =>
                    policy.RequireRole("Sestra"));
      options.AddPolicy("LekarOrSestra",policy=> policy.RequireRole("Lekar","Sestra")
                    
                    );
              
            });
          
            services.AddScoped<TokenService>();
            return services;
        }
    }
}
