using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yemekoneri.Context;

namespace yemekoneri.Bussiness
{
    static class DbContextService
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();

            services.AddDbContext<YemekOneriDbContext>(x => x.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=yemekdb2;Trusted_Connection=True;"));
            return services;
        }
    }
}
