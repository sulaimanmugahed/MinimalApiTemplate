using MediatR;
using MinimalApiTemplate.Application.Dtos.Products;
using MinimalApiTemplate.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiTemplate.Application.Features.Products.Queries.GetProductById;
public class GetProductByIdQuery:IRequest<BaseResult<ProductDto>>
{
    public Guid Id { get; set; }
}
