using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using movies.data.dbContext;
using movies.domain.data_interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace movies.data
{
    public static class DataDependencyResolver
    {
        public static IServiceCollection AddDBServices(this IServiceCollection service,IConfiguration configuration )
        {
            service.AddDbContext<MovieDBContext>(option => option.UseSqlServer(configuration.GetConnectionString("MovieDatabase")));
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserSerachLogRepository, UserSearchLogRepository>();
            return service;
        }
    }
}
