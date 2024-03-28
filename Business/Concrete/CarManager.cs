using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddCar()
        {
            Car car = new Car();
            Console.Write("Enter the car name: ");
            car.Description = Console.ReadLine();
            Console.Write("Enter the car daily price: ");
            car.DailyPrice=Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter the car ıd: ");
            car.CarId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the brand ıd: ");
            car.BrandId= Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the color ıd: ");
            car.ColorId= Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the mdoel year : ");
            car.ModelYear = Console.ReadLine();

            if (car.Description.Length > 2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("Car added with "+car.Description+" name");
            }    
            else
            {
                Console.WriteLine("Car name cannot be less than two characters and it' price cannot be zero"); ;
            }
        
        }

       

       

        public void Delete(int carId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p=>p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

      

        public void Update(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
