using MediatR;
using MinimalApiTemplate.Application.Contracts;
using MinimalApiTemplate.Application.Contracts.Persistence;
using MinimalApiTemplate.Application.Dtos.Products;
using MinimalApiTemplate.Application.Exceptions;
using MinimalApiTemplate.Application.Wrappers;
using MinimalApiTemplate.Domain.Products;


namespace MinimalApiTemplate.Application.Features.Products.Commands.DeleteProduct;
public class DeleteProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) 
    : IRequestHandler<DeleteProductCommand, BaseResult>
{
    public async Task<BaseResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(new ProductId(request.Id));
        if (product is null)
            throw new ApplicationNotFoundException("no product with this id", nameof(request.Id));

        productRepository.Delete(product);
        await unitOfWork.SaveChangesAsync();

        return new BaseResult();
    }
}
