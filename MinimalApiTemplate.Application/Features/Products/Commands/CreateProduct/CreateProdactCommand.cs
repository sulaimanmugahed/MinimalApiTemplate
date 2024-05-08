using MediatR;
using MinimalApiTemplate.Application.Wrappers;


namespace MinimalApiTemplate.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<BaseResult<string>>, IProductCommand
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
