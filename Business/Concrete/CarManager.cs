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

        public void AddCar(Car car)
        {
            
            Console.WriteLine("Enter the car name: ");
            string name=Console.ReadLine();
            Console.WriteLine("Enter the car daily price: ");
            decimal price=Convert.ToDecimal(Console.ReadLine());
            if (name.Length > 2 && price>0)
            {
                _carDal.Add(car);
                Console.WriteLine("Car added with "+name+" name");
            }    
            else
            {
                Console.WriteLine("Car name cannot be less than two characters and it' price cannot be zero"); ;
            }
        
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
    }
}
