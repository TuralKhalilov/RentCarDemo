using Business.Abstrack;
using Core.Utulities.Business;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult AddRent(Rental rental)
        {
            var result = BusinessRules.Run( CheckAddRental(rental));

            if (result!=null)
            {
                return result;
            }
            
            _rentalDal.Add(rental);
            return new SuccessResult();


        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

        public IResult ReturnRent(Rental rental)
        {
             _rentalDal.Update(new Rental { Id = rental.Id, ReturnDate = rental.ReturnDate });
            return new SuccessResult();
        }

        private IResult CheckAddRental(Rental rental)
        {
            var initResult = _rentalDal.GetAll(x => x.CarId == rental.CarId).Count();
            if (initResult < 1)
            {
                
                return new SuccessResult();
            }

            var nullresult = _rentalDal.GetAll(x => x.ReturnDate == new DateTime(0001, 01, 01) && x.CarId == rental.CarId).Any();

            if (nullresult)
            {
                return new ErorResult();

            }

           
            return new SuccessResult();
        }


       
       
    }


}
