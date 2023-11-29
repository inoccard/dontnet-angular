﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;

namespace Proagil.WebAPI.Configs.Authentication
{
    public static class AuthenticationConfig
    {
        public static void AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = false;
                    opt.SaveToken = true;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        // assinatura da chave do emissor
                        ValidateIssuerSigningKey = true,
                        // config da chave da API
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        SaveSigninToken = true
                    };
                })
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "";
                    options.ApiName = "";
                    options.ApiSecret = "";
                    options.CacheDuration = TimeSpan.FromMinutes(99);
                    options.EnableCaching = true;
                    options.RoleClaimType = ClaimTypes.Role;
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthorization();
        }

        public static void UseIdentityConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}