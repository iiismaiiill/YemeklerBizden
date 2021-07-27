using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using yemekoneri.Bussiness.Abstract;
using yemekoneri.Context;

namespace yemekoneri.Bussiness.EfRepositories
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly YemekOneriDbContext context;
        public EfGenericRepository()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContextService();
            ServiceProvider provider = services.BuildServiceProvider();

            context = provider.GetService<YemekOneriDbContext>();
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
