using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator <NCar>
    {
        public CarValidator()
        {
            RuleFor(p => p.Description).MinimumLength(2);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(1);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(5000).When(p => p.BrandId == 1).WithMessage("Fiyat bilgisi 5000'den büyük yada eşit olmalıdır.");
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.ModelYear).NotEmpty();

         //   RuleFor(p => p.Description).Must(StartWithA);


        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
