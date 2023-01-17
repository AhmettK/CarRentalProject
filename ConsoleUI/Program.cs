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

            //CarBrandColorTest();

            //CustomerTest();

            //RentalAddTest();
        }

        private static void RentalAddTest()
        {
            Rental rental1 = new Rental() { CarId = 2, CustomerId = 2, RentDate = DateTime.Now.AddDays(1), ReturnDate = DateTime.Now.AddDays(3) };
            IRentalService rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(rental1);
            Console.WriteLine(result.Message);
        }

        private static void CustomerTest()
        {
            Customer customer1 = new Customer() { FirstName = "Tuğçe", LastName = "Tuncay", Email = "tugce@gmail.com", Password = "12345", CompanyName = "Tuğçe Ticaret" };
            ICustomerService customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(customer1);
        }

        private static void CarBrandColorTest()
        {
            ICarService carManager = new CarManager(new EfCarDal());
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            IColorService colorManager = new ColorManager(new EfColorDal());

            var result = carManager.GetCarDetails();
            Console.WriteLine(result.Message);
            foreach (var car in result.Data)
            {
                Console.WriteLine("Araba Markası: " + car.BrandName + "-- Araba Modeli: " + car.CarName + "-- Araba Rengi: " + car.ColorName + "\n");
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
            var cars = carManager.GetAll().Data;
            foreach (var item in cars)
            {
                Console.WriteLine(item.Description);
            }

            //getById() operasyonu
            var car3 = carManager.GetById(5).Data;
            Console.WriteLine("\ngetById: " + car3.Description);
        }
    }
}
