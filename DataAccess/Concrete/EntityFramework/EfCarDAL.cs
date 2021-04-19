using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDAL:ICarDAL
    {
        public List<NCar> GetAll(Expression<Func<NCar, bool>> filter = null)
        {
            using (ProjectDBContext context = new ProjectDBContext())
            {
                return filter == null
                    ? context.Set<NCar>().ToList()
                    : context.Set<NCar>().Where(filter).ToList();
            }
        }

        public NCar Get(Expression<Func<NCar, bool>> filter)
        {
            using (ProjectDBContext context = new ProjectDBContext())
            {
                return context.Set<NCar>().SingleOrDefault(filter);
            }
        }

        public void Add(NCar entity)
        {
            using (ProjectDBContext context = new ProjectDBContext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(NCar entity)
        {
            using (ProjectDBContext context = new ProjectDBContext())
            {
                var updatedEntity= context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(NCar entity)
        {
            using (ProjectDBContext context = new ProjectDBContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }
    }
}
