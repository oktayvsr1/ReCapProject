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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult AddColor(Color color)
        {
            _colorDal.Add(color);
            return new Result(true,Messages.CarAdded);

        }

       

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Gett(c => c.ColorId == colorId));

        }

        public IResult RemoveColor(Color color)
        {
            _colorDal.Delete(color);
            return new Result(true,Messages.CarDeleted);
        }

        public IResult UpdateColor(Color color)
        {
            _colorDal.Update(color);
            return new Result(true,Messages.carUpdated);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        
    }
}
