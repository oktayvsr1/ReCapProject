using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars;
        public InMemoryCarDal()
        {
            cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=2,DailyPrice=2500,ModelYear="2009",Description="Passat"},
                new Car{Id=2,BrandId=1,ColorId=3,DailyPrice=2000,ModelYear="2015",Description="Golf"},
                new Car{Id=3,BrandId=2,ColorId=1,DailyPrice=2300,ModelYear="2012",Description="Symbol"},
                new Car{Id=4,BrandId=2,ColorId=2,DailyPrice=2100,ModelYear="2022",Description="Talisman"},
                new Car{Id=5,BrandId=3,ColorId=4,DailyPrice=2400,ModelYear="2023",Description="Focus"},
                new Car{Id=6,BrandId=3,ColorId=5,DailyPrice=2700,ModelYear="2020",Description="Fiesta"},
            };

        }

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete= cars.SingleOrDefault(p=>p.Id==car.Id);
            cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllById(int id)
        {
           return cars.Where(c=>c.Id==id).ToList();
        }

        public Car Gett(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car cartoUpdate= cars.SingleOrDefault(p=>p.Id==car.Id);
            cartoUpdate.Id = car.Id;
            cartoUpdate.BrandId = car.BrandId;
            cartoUpdate.ColorId = car.ColorId;
            cartoUpdate.DailyPrice = car.DailyPrice;
            cartoUpdate.DailyPrice=car.DailyPrice;
        }
    }
}
