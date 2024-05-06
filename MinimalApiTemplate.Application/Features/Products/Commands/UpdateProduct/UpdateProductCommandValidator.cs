﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiTemplate.Application.Features.Products.Commands.UpdateProduct;
public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        Include(new IProductCommandValidator());
    }
}
