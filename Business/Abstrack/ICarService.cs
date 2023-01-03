using Core.Utulities;
using Core.Utulities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstrack
{
  public  interface ICarService
    {
        IResult Add(Car car);
       IDataResult < List<Car>> GetAll();
        IDataResult<Car> GetById();
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
