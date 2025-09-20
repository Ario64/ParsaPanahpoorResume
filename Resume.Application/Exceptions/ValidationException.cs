using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Resume.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public List<string> Exceptions { get; set; } = new();

    public ValidationException(ValidationResult result)
    {
        foreach (var err in result.Errors)
        {
            Exceptions.Add(err.ErrorMessage);
        }
    }
}
