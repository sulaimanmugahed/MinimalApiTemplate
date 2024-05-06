using MediatR;
using MinimalApiTemplate.Application.Dtos.Products;
using MinimalApiTemplate.Application.Wrappers;


namespace MinimalApiTemplate.Application.Features.Products.Queries.GetProductList;
public class GetProductListQuery : IRequest<BaseResult<List<ProductDto>>>
{
}
