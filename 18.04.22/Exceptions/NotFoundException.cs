using System;
using System.Collections.Generic;
using System.Text;

namespace _18._04._22.Exceptions
{
    internal class NotFoundException:Exception
    {
        public NotFoundException(string message):base(message)  
        {

        }
    }
}
