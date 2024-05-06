using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalApiTemplate.Api.Infrastructure.Filters;
using MinimalApiTemplate.Application.Dtos.Products;
using MinimalApiTemplate.Application.Features.Products.Commands.CreateProduct;
using MinimalApiTemplate.Application.Features.Products.Commands.DeleteProduct;
using MinimalApiTemplate.Application.Features.Products.Commands.UpdateProduct;
using MinimalApiTemplate.Application.Features.Products.Queries.GetProductById;
using MinimalApiTemplate.Application.Features.Products.Queries.GetProductList;
using MinimalApiTemplate.Application.Wrappers;


namespace MinimalApiTemplate.Api.Endpoints.v1;

public static class ProductsEndpoint
{
    public static void MapProductsEndpointV1(this IEndpointRouteBuilder routeBuilder)
    {
        var app = routeBuilder.MapGroup("/products")
        .WithTags("Products")
        .WithDescription("Your Endpoint Descriptions")
        .MapToApiVersion(1)
        .WithOpenApi();

        
        app.MapGet("/", GetProductList);
        app.MapGet("/{id:guid}", GetProductById);

		// add the addendpointfilter to the endpint that has Fluent Validators 
		app.MapPost("/", CreateProduct)
            .AddEndpointFilter<ValidationFilter<CreateProductCommand>>();
        app.MapPut("/{id:guid}", UpdateProduct)
            .AddEndpointFilter<ValidationFilter<UpdateProductCommand>>(); 

		app.MapDelete("/{id:guid}", DeleteProduct);

    }


   
    private static async Task<BaseResult<List<ProductDto>>> GetProductList([FromServices] IMediator mediator)
        => await mediator.Send(new GetProductListQuery());

    private static async Task<BaseResult<ProductDto>> GetProductById([FromServices] IMediator mediator,[FromRoute]Guid id)
        => await mediator.Send(new GetProductByIdQuery { Id = id });

 
    private static async Task<BaseResult<string>> CreateProduct(CreateProductCommand model, [FromServices] IMediator mediator)
        => await mediator.Send(model);


    private static async Task<BaseResult> UpdateProduct([FromRoute]Guid id,UpdateProductCommand model, [FromServices] IMediator mediator)
    {
        model.Id = id;
        return await mediator.Send(model);
    }

    [Authorize]
    private static async Task<BaseResult> DeleteProduct([FromRoute] Guid id, [FromServices] IMediator mediator)
        => await mediator.Send(new DeleteProductCommand { Id = id });

}
