using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarSevice
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<Car> GetByDailyPrice(int min, int max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public Car GeyById(int id)
        {
            return _carDal.Get(p => p.CarId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
