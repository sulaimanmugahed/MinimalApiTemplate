using MediatR;
using MinimalApiTemplate.Application.Contracts;
using MinimalApiTemplate.Application.Contracts.Persistence;

using MinimalApiTemplate.Application.Wrappers;
using MinimalApiTemplate.Domain.Products.Entities;


namespace MinimalApiTemplate.Application.Features.Products.Commands.CreateProduct;

public class CreateProdactCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateProductCommand, BaseResult<string>>
{
    public async Task<BaseResult<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(request.Name, request.Description,request.Price);

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();

        return new BaseResult<string>(product.Id.Value.ToString());
    }
}

