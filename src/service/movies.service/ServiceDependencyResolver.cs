using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using movies.domain.data_interface;
using movies.domain.service_interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace movies.service
{
    public static class ServiceDependencyResolver
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection service )
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserSearchLogService, UserSearchLogService>();
            service.AddScoped<IHttpClientService, HttpClientService>();

            return service;
        }
    }
}
