using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryTest();

            ICarService carManager = new CarManager(new EfCarDal());
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            IColorService colorManager = new ColorManager(new EfColorDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Araba Markası: "+car.BrandName+"-- Araba Modeli: "+car.CarName+"-- Araba Rengi: "+car.ColorName+"\n");
            }
        }

        private static void InMemoryTest()
        {
            ICarService carManager = new CarManager(new InMemoryCarDal());

            //ADD & DELETE
            Car car1 = new Car { Id = 6, BrandId = 3, ColorId = 3, ModelYear = 2010, DailyPrice = 500, Description = "150 Beygir" };
            carManager.Add(car1);
            carManager.Delete(car1);

            //UPDATE
            Car car2 = new Car { Id = 3, BrandId = 3, ColorId = 3, ModelYear = 1997, DailyPrice = 275, Description = "105 Beygir" };
            carManager.Update(car2);

            //getAll() operasyonu
            var cars = carManager.GetAll();
            foreach (var item in cars)
            {
                Console.WriteLine(item.Description);
            }

            //getById() operasyonu
            var car3 = carManager.GetById(5);
            Console.WriteLine("\ngetById: " + car3.Description);
        }
    }
}
