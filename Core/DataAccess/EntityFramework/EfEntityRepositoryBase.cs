using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IGenericDal<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity t)
        {
            using(TContext context=new TContext())
            {
                var Added=context.Entry(t);
                Added.State= EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var deleted = context.Entry(t);
                deleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>>? filter = null)
        { 
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).SingleOrDefault();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter==null?context.Set<TEntity>().ToList(): 
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var updated = context.Entry(t);
                updated.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
