using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planner.API.Controllers;
using Planner.Core.Domain;
using Planner.Infrastructure.Data;
using Planner.Infrastructure.Interface;
using Planner.Infrastructure.Repository;
using Planner.Infrastructure.Service;
using AutoMapper;
using Planner.Infrastructure.Validation;
using System;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Planner.API.Configuration;

namespace Planner.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
			services.AddDbContext<PlannerContext>
					(options => options.UseInMemoryDatabase(connection));

			//services.AddScoped<IProjectRepository, ProjectRepository>();
           //services.AddScoped<IProjectService, ProjectService>();
            //services.AddScoped<IProjectValidation, ProjectValidation>();
            
            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            this.ApplicationContainer = ContainerConfig.Configure(services);

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}
