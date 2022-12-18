using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
