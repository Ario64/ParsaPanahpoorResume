using System;

namespace Resume.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"{name} {key} پیدا نشد !") { }
}
