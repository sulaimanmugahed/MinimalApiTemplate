using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiTemplate.Application.Exceptions;
public class ApplicationNotFoundException : Exception
{
    public ApplicationNotFoundException(string errorMessage = "Not Found!",string? fieldName = null)
        : base(errorMessage)
    {    
        ErrorMessage = errorMessage;
        FieldName = fieldName;
    }
    public string ErrorMessage { get; init; }
    public string? FieldName { get; init; }

   
   
}
