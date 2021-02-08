using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=3, ModelYear=2010, DailyPrice=50000, Description="Fiat"},
                new Car{Id=2, BrandId=1, ColorId=1, ModelYear=2001, DailyPrice=35000, Description="Honda"},
                new Car{Id=3, BrandId=2, ColorId=4, ModelYear=2020, DailyPrice=120000, Description="Toyota"},
                new Car{Id=4, BrandId=3, ColorId=6, ModelYear=1985, DailyPrice=75000, Description="Chevrolet"},
                new Car{Id=5, BrandId=3, ColorId=5, ModelYear=2006, DailyPrice=40000, Description="Wolksvagen"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
