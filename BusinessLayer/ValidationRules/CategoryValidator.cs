using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Categori adını boş bırakmayınız.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Categori açıklamasını boş bırakmayınız.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Categori adı en az 3 karakter giriniz .");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Categori adı en fazla 20 karakter giriniz .");
        }
    }
}
