using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator <NRental>
    {

        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.RentDate).NotEmpty().GreaterThan(DateTime.Now).WithMessage("Kiralama Tarihi Geçmiş Tarih Olamaz!");
            RuleFor(r => r.ReturnDate).NotEmpty().GreaterThanOrEqualTo(r => r.RentDate).WithMessage("Aracın Teslim Tarihi Kiralama Tarihinden Önce Olamaz!");

        }
    }
}

        