using MediatR;
using MinimalApiTemplate.Application.Contracts.Persistence;
using MinimalApiTemplate.Application.Contracts;
using MinimalApiTemplate.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalApiTemplate.Domain.Products;
using MinimalApiTemplate.Application.Dtos.Products;
using MinimalApiTemplate.Application.Exceptions;

namespace MinimalApiTemplate.Application.Features.Products.Commands.UpdateProduct;
public class UpdateProductCommandHandler (
     IProductRepository productRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateProductCommand, BaseResult>
{
    public async Task<BaseResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(new ProductId(request.Id));
        if (product is null)
            throw new ApplicationNotFoundException("no product with this id", nameof(request.Id));

        product.Update(request.Name, request.Description,request.Price);
        await unitOfWork.SaveChangesAsync();

        return new BaseResult();

    }
}
