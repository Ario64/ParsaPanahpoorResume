using System;

namespace Resume.Application.Exceptionsک
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message) { }
    }
}
