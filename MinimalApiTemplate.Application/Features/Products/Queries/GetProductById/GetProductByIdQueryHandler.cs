using MediatR;
using MinimalApiTemplate.Application.Contracts.Persistence;
using MinimalApiTemplate.Application.Dtos.Products;
using MinimalApiTemplate.Application.Exceptions;
using MinimalApiTemplate.Application.Wrappers;
using MinimalApiTemplate.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiTemplate.Application.Features.Products.Queries.GetProductById;
public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, BaseResult<ProductDto>>
{
    public async Task<BaseResult<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
      var product = await productRepository.GetByIdAsync(new ProductId(request.Id));
        if (product is null)
            throw new ApplicationNotFoundException("no product with this id",nameof(request.Id));

        return new BaseResult<ProductDto>(new ProductDto(product));


    }
}
