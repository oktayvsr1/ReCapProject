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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (AvsarCarContext context = new AvsarCarContext())
            {
                var addedColor = context.Entry(entity);
                addedColor.State= Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (AvsarCarContext context = new AvsarCarContext())
            {
                var deletedColor = context.Entry(entity);
                deletedColor.State=Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (AvsarCarContext context= new AvsarCarContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList();
            }
        }

        public Color Gett(Expression<Func<Color, bool>> filter)
        {
            using (AvsarCarContext context = new AvsarCarContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public void Update(Color entity)
        {
            using (AvsarCarContext context = new AvsarCarContext())
            {
                var updatedColor = context.Entry(entity);
                updatedColor.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
