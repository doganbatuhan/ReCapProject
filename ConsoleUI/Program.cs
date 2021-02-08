using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            // Print whole items of cars
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("********************");
            // Print a car which has specific id
            foreach (var car in carManager.GetById(2))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("********************");
            // Print a car which has specific id
            foreach (var car in carManager.GetById(4))
            {
                Console.WriteLine(car.Description);
            }

        }
    }
}
