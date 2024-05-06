using MediatR;
using MinimalApiTemplate.Application.Contracts.Persistence;
using MinimalApiTemplate.Application.Dtos.Products;
using MinimalApiTemplate.Application.Wrappers;
using MinimalApiTemplate.Domain.Products.Entities;


namespace MinimalApiTemplate.Application.Features.Products.Queries.GetProductList;
public class GetProductListQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductListQuery, BaseResult<List<ProductDto>>>
{
    public async Task<BaseResult<List<ProductDto>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllAsync();

        return new BaseResult<List<ProductDto>>(products.Select(p => new ProductDto(p)).ToList());
    }
}
