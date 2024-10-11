using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using StudentRegister.Application.Course.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(assembly);
            });
            services.AddValidatorsFromAssembly(assembly);
            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
