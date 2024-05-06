using MediatR;
using MinimalApiTemplate.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiTemplate.Application.Features.Products.Commands.DeleteProduct;
public class DeleteProductCommand:IRequest<BaseResult>
{
    public Guid Id { get; set; }
}
