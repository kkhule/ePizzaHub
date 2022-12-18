using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Exceptions
{
    public class FileNotFoundException : NotFoundException
    {
        public FileNotFoundException(string exception, Exception? innerException) : base(exception, innerException)
        {
        }
    }
}
