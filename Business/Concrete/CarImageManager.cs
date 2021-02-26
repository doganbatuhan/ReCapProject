using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public IResult Add(CarImage image)
        {
            var result = BusinessRules.Run(CheckIfImageCountOfCarExceeded(image.CarId));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Add(image);
            return new SuccessResult();
        }

        public IResult Delete(CarImage image)
        {
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

        public IResult Update(CarImage image)
        {
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
