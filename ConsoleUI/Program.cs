using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            // Print whole items of cars
            foreach (var car in carManager.GetByDailyPrice(80000, 500000))
            {
                Console.WriteLine(car.Description);
            }

        }
    }
}
