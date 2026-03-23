using FluentValidation;
using MondayFunday.Models;

namespace MondayFunday.Validators
{
    public class AllValidators
    {

        public class CategoryValidator : AbstractValidator<Category>
        {
            public CategoryValidator()
            {
                RuleFor(category => category.Name)
                    .NotEmpty().WithMessage("Category name is required.")
                    .MaximumLength(50).WithMessage("Category name cannot exceed 50 characters.");
                RuleFor(nemo => nemo.Id).Must(id => id > 0)
                    .GreaterThan(0).WithMessage("A valid Id is required.");
            }
        }

        public class ProductValidator : AbstractValidator<Product>
        {
            public ProductValidator()
            {
                RuleFor(p => p.Name)
                    .NotEmpty().WithMessage("Product name is required.")
                    .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");

                RuleFor(p => p.Price)
                    .GreaterThan(0).WithMessage("Price must be greater than 0.")
                    .LessThan(10000).WithMessage("Price cannot exceed 10,000.");

                RuleFor(p => p.CategoryId)
                    .GreaterThan(0).WithMessage("A valid CategoryId is required.");
            }
        }

        public class ReviewValidator : AbstractValidator<Review>
        {
            public ReviewValidator()
            {
                RuleFor(r => r.ProductId)
                    .GreaterThan(0).WithMessage("A valid ProductId is required.");

                RuleFor(r => r.Comment)
                    .NotEmpty().WithMessage("Comment is required.")
                    .MaximumLength(500).WithMessage("Comment cannot exceed 500 characters.");

                RuleFor(r => r.Rating)
                    .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");
            }
        }
    }
}
