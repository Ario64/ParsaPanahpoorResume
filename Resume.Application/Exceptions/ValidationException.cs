using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resume.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public List<string> Exceptions { get; set; } = new();

    public ValidationException(ValidationResult result)
    {
        foreach (var exc in result.ErrorMessage)
        {
            Exceptions.Add(exc.ToString());
        }
    }
}
