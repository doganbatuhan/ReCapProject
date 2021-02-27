using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage image, IFormFile file)
        {
            var result = BusinessRules.Run(CheckIfImageCountOfCarExceeded(image.CarId));

            if (result != null)
            {
                return result;
            }
            var path = FileProcess.Create(file, Paths.ImagesPath);
            image.ImagePath = path;
            image.Date = DateTime.Now;
            _carImageDal.Add(image);
            return new SuccessResult();
        }

        public IResult Delete(CarImage image)
        {

            FileProcess.Delete(_carImageDal.Get(i=>i.Id == image.Id).ImagePath);
            _carImageDal.Delete(image);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == id));
        }

        public IResult Update(CarImage image, IFormFile file)
        {
            var path = FileProcess.Update(file, _carImageDal.Get(i => i.Id == image.Id).ImagePath);
            image.ImagePath = path;
            image.Date = DateTime.Now;
            _carImageDal.Update(image);
            return new SuccessResult();
        }

        private IResult CheckIfImageCountOfCarExceeded(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageCountOfCarError);
            }
            return new SuccessResult();
        }

    }
}
