using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Planner.Infrastructure.Interface;
using Planner.Infrastructure.Repository;
using Planner.Infrastructure.Service;
using Planner.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Planner.API.Configuration
{
    public static class ContainerConfig
    {
        public static IContainer Configure(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);
            // builder.RegisterType<ProjectRepository>().As<IProjectRepository>();
            // builder.RegisterType<ProjectService>().As<IProjectService>();
            //builder.RegisterType<ProjectValidation>().As<IProjectValidation>();

            builder.RegisterAssemblyTypes(Assembly.Load("Planner.Infrastructure"))
             .Where(t => t.IsAssignableTo<IValidation>())
             .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load("Planner.Infrastructure"))
             .Where(t => t.IsAssignableTo<IService>())
             .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load("Planner.Infrastructure"))
             .Where(t => t.IsAssignableTo<IRepository>())
             .AsImplementedInterfaces();
           
            return builder.Build();
        }
    }
}
