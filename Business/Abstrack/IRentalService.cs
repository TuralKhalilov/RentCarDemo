using Core.Utulities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstrack
{
   public interface IRentalService
    {
        IResult AddRent(Rental rental);
        IResult ReturnRent(int id, DateTime returnTime);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
    }
}
