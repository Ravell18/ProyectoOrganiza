using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrganiZa.Infraestructure.Data;
using OrganiZa.Infraestructure.Repositories;
using AutoMapper;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using OrganiZa.Domain.Interfaces;
using OrganiZa.Application.Services;
using Microsoft.AspNetCore.Hosting;

namespace OrganiZa.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddDbContext<OrganizarecContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("Missael"))
          );

            services.AddMvc().AddFluentValidation(options =>
                     options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ITutorService, TutorService>();
            services.AddTransient<IPagosService, PagoService>();
            services.AddTransient<IAdministradorService, AdministradorService>();
            services.AddTransient<IEscuelaService, EscuelaService>();
            services.AddTransient<ICalendarioServicio, CalendarioService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.WithOrigins("https://localhost:44374");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        } 
    }
}

