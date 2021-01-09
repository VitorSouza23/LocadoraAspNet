using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using LocadoraAspNet.Extensions;
using LocadoraAspNet.InfraData.Contexts;
using LocadoraAspNet.InfraData.Features.Genres;
using LocadoraAspNet.InfraData.Features.Locations;
using LocadoraAspNet.InfraData.Features.Movies;
using LocadoraAspNet.Models.Features.Genres;
using LocadoraAspNet.Models.Features.Locations;
using LocadoraAspNet.Models.Features.Movies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LocadoraAspNet
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddApiExplorer()
                .AddFluentValidation(fvc =>
                            fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddMediator();
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AspNetDockerContext")));

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ILocationRepository, LocationRespository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
