using Business.Abstrack;
using Business.Constants;
using Core.Utulities.Business;
using Core.Utulities.Helpers.FileHelper;
using Core.Utulities.Results;
using DataAccess.Abstrack;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
          var result=  BusinessRules.Run(CheckImageCountLimit(carImage.CarId), CheckNullValueforDefault(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
           
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagePath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
          return new SuccessDataResult<List<CarImage>>(  _carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            _fileHelper.Updete(file, PathConstants.ImagePath + carImage.ImagePath, PathConstants.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckImageCountLimit(int carId )
        {
          var result=  _carImageDal.GetAll(c=>c.CarId==carId).Count();
            if (result<=5)
            {
                return new SuccessResult();
            }
            return new ErorResult();
        }


        private IResult CheckNullValueforDefault(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if (result > 1)
            {
                return new SuccessResult();
            }

            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.png" });
            return new SuccessResult();
        }
    }
}
