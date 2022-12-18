using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
