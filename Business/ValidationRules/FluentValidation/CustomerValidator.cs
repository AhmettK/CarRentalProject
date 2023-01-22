using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Password).MinimumLength(5).WithMessage("Parolanız en az beş karakterden oluşmalı.");
            RuleFor(c => c.CompanyName).MinimumLength(5).WithMessage("Şirket adınız en az beş karakterden oluşmalı.");
        }
    }
}
