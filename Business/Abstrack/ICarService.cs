﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstrack
{
  public  interface ICarService
    {
        void Add(Car car);
        List<Car> GetAll();
    }
}