using Business.Abstrack;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utulities;
using Core.Utulities.Results;
using DataAccess.Abstrack;
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

        [ValidationAspect(typeof( CarValidator))]
        public IResult Add(Car car)
        {
              _carDal.Add(car);

            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public IDataResult< List<Car>> GetAll()
        {
            var resut = _carDal.GetAll();
            if (resut==null)
            {
                return new ErorDataResult<List<Car>>(resut);
            }
            return new SuccessDataResult<List<Car>>(resut);
        }

        public IDataResult<Car> GetById()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
