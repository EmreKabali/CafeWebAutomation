using FluentValidation;
using MVCUI.SecurityLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUI.Validation.FluentValidation
{
    public class LoginValidator:AbstractValidator<LoginVM>
    {

        public LoginValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email adresini email formatında giriniz");


        }

    }
}