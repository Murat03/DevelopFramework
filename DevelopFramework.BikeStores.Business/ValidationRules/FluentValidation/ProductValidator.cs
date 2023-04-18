using DevelopFramework.BikeStores.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.Business.ValidationRules.FluentValidation
{
    public class ProductValidatior:AbstractValidator<Product>
    {
        public ProductValidatior()
        {
            RuleFor(p => p.category_id).NotEmpty();
            RuleFor(p => p.product_name).NotEmpty().WithMessage("Product Name Cannot Be Empty!");
            RuleFor(p => p.list_price).GreaterThan(0);
            RuleFor(p => p.product_name).Length(2,20);
            RuleFor(p => p.model_year).NotEmpty();
            RuleFor(p => p.list_price).GreaterThan(20).When(p => p.category_id == 1);
            //RuleFor(p => p.product_name).Must(StartWithA);
        }

        private bool StartWith(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
