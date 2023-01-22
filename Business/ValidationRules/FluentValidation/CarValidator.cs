using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2).WithMessage("Araba adı en az iki harften oluşmalı.");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Günlük fiyat 0 TL'den büyük olmalı.");
        }
    }
}
