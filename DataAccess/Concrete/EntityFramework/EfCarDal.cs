using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (AvsarCarContext context = new AvsarCarContext())
            {
                var addedEntity=context.Entry(entity);
                addedEntity.State=Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (AvsarCarContext context = new AvsarCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (AvsarCarContext context = new AvsarCarContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car Gett(Expression<Func<Car, bool>> filter)
        {
            using (AvsarCarContext context = new AvsarCarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Update(Car entity)
        {
            using (AvsarCarContext context = new AvsarCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
