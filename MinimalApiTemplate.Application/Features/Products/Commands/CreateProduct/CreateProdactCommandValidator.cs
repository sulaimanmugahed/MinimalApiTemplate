using FluentValidation;


namespace MinimalApiTemplate.Application.Features.Products.Commands.CreateProduct;

public class CreateProdactCommandValidator : AbstractValidator<CreateProductCommand>
{
   public CreateProdactCommandValidator()
   {
      Include(new IProductCommandValidator());
    }
}
