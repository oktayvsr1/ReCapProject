using Azure.Messaging;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return  new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Gett(b=>b.BrandId==brandId));
        }

        public IResult AddBrand(Brand brand)
        {
            _brandDal.Add(brand);
            return new Result(true, Messages.CarAdded);
        }

        public IResult DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(true,Messages.CarDeleted);
        }

        public IResult UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(true,Messages.carUpdated);
        }

        
    }
}
