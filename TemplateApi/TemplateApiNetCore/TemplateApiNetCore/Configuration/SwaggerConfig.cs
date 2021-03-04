﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;


namespace TemplateApiNetCore.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TemplateAPI",
                    Description = "Esta API Template",
                    Contact = new OpenApiContact() { Name = "Jack Wesley Moreira", Email = "jackwesley@hotmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensourse.org/licenses/MIT") }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
            });

            return app;
        }
    }
}
