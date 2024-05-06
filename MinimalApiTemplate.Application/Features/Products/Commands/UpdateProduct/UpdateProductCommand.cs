using MediatR;
using MinimalApiTemplate.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MinimalApiTemplate.Application.Features.Products.Commands.UpdateProduct;
public class UpdateProductCommand :IRequest<BaseResult> ,IProductCommand
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
