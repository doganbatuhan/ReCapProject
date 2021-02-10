using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarSevice
    {
        List<Car> GetAll();
        Car GeyById(int id);
        List<Car> GetAllByBrandId(int id);
        List<Car> GetAllByColorId(int id);
        List<Car> GetByDailyPrice(int min, int max);
        List<CarDetailDto> GetCarDetails();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
