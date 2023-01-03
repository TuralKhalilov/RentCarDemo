using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utulities.Results
{
  public  class ErorDataResult <T> :DataResult<T>
    {
        public ErorDataResult(T data , string message):base(false,message,data)
        {

        }
        public ErorDataResult(T data):base(false,data)
        {

        }
    }
}
