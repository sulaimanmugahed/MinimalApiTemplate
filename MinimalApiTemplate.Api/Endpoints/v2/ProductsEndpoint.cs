using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalApiTemplate.Api.Infrastructure.Filters;
using MinimalApiTemplate.Application.Dtos.Products;
using MinimalApiTemplate.Application.Features.Products.Queries.GetProductList;
using MinimalApiTemplate.Application.Wrappers;


namespace MinimalApiTemplate.Api.Endpoints.v2
{
	public static class ProductsEndpoint
	{
		public static void MapProductsEndpointV2(this IEndpointRouteBuilder routeBuilder)
		{
			var app = routeBuilder.MapGroup("/products")
			.WithTags("Products")
			.WithDescription("Your Endpoint Descriptions")
			.MapToApiVersion(2)
			.WithOpenApi();
			app.MapGet("/", GetProducts);

		}


		[Authorize]
		private static async Task<BaseResult<List<ProductDto>>> GetProducts([FromServices] IMediator mediator)
			=> await mediator.Send(new GetProductListQuery());
	}




}
