﻿using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {

        public RentalValidator( )
        {
            RuleFor(r => r.ReturnDate).GreaterThanOrEqualTo(r => r.RentDate)
                .WithMessage("Teslim edilme tarihi kiralama " +
                "tarihiyle aynı gün veya daha sonra olmalıdır");
        }


    }
}