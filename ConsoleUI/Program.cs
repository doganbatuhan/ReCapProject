﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetCarDetailTest();

            //AddCarTest();

            //UpdateCarTest();

            //DeleteCarTest();

            //GetCarByIdTest();

        }

        private static void GetCarByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car = carManager.GeyById(7);
            Console.WriteLine(car.Description + " " + car.DailyPrice);
        }

        private static void DeleteCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Delete(new Car { CarId = 8 });
        }

        private static void UpdateCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Update(new Car
            {
                CarId = 8,
                BrandId = 12,
                ColorId = 10,
                DailyPrice = 65000,
                ModelYear = 2006,
                Description = "Önden Çekişli"
            });
        }

        private static void AddCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car
            {
                BrandId = 4,
                ColorId = 6,
                DailyPrice = 15000,
                ModelYear = 2000,
                Description = "SUV"
            });
        }

        private static void GetCarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            // Print whole items of cars
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} : {1} : {2} : {3}", car.CarName,
                    car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
    }
}
