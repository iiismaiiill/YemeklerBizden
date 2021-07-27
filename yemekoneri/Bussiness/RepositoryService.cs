using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yemekoneri.Bussiness.Abstract;
using yemekoneri.Bussiness.EfRepositories;

namespace yemekoneri.Bussiness
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            //services.AddTransient<IGenericRepository<Plan>>(x => new EfPlanRepository());            
            //services.AddTransient<IGenericRepository<Activity>>(x => new EfActivityRepository());
            //services.AddTransient<IGenericRepository<Accommodation>>(x => new EfAccommodationRepository());
            //services.AddTransient<IGenericRepository<User>>(x => new EfUserRepository());
            services.AddTransient<IYemekRepository, EfYemekRepository>();
            services.AddTransient<IYorumRepository, EfYorumRepository>();
            services.AddTransient<IKullaniciRepository, EfKullaniciRepository>();
            return services;
        }
    }
}
