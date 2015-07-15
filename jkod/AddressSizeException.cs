using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jkod
{
    class AddressSizeException : Exception
    {
        public AddressSizeException() 
            : base("The number of bytes per line must be a multiple of the number of columns.")
        { 
            //nothing
        }
    }
}
