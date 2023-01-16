using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                var result=from car in context.Cars join b in context.Brands
                           on car.BrandId equals b.Id join color in context.Colors
                           on car.ColorId equals color.Id select new CarDetailDto
                           { CarId=car.Id,CarName=car.Description,BrandName=b.Name,ColorName=color.Name,DailyPrice=car.DailyPrice};
                return result.ToList();
            }
        }
    }
}
