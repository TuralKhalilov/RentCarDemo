using Business.Abstrack;
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
            var result = _rentalDal.GetAll(x => x.CarId == rental.CarId).Count();
            if (result < 1)
            {
                _rentalDal.Add(new Rental { CarId = rental.CarId, CustomerId = 1, RentDate = new DateTime(2022, 12, 2), ReturnDate = new DateTime(2022, 12, 2) });
            }



            var nullresult = _rentalDal.GetAll(x => x.ReturnDate == new DateTime(0001,01,01) && x.CarId == rental.CarId).Any();

            if (nullresult)
            {
                return new ErorResult();

            }
            
            _rentalDal.Add(rental);
            return new SuccessResult();


        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult ReturnRent(int id, DateTime returnTime)
        {
            throw new NotImplementedException();
        }

        //private IResult CheckAddRental(Rental rental)
        //{
        //    var nullresult = _rentalDal.GetAll(x => x.ReturnDate == null && x.CarId == rental.CarId).Any();

        //    if (nullresult)
        //    {
        //        _rentalDal.Add(rental);
        //        return new SuccessResult();
        //    }
        //    return new ErorResult(); 

        //}
    }
}
